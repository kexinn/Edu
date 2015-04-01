using System;
using System.Collections.Generic;

using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace BLL.pub
{
    /// <summary>
    /// Abstract Linq repository base class written by Adrian Grigore
    /// 
    /// RepositoryBase supports disconnected mode and recursive saving / deleting of linq entities
    /// 
    /// Feel free to stop by my development blog at www.devermind.com !
    /// </summary>
    /// <typeparam name="TEntityType"></typeparam>
    /// <typeparam name="TContextType"></typeparam>
    public abstract class RepositoryBase<TEntityType, TContextType>
        where TEntityType : class
        where TContextType : DataContext, new()
    {
        protected RepositoryBase()
        {
            //make sure TEntityType and all associated entities are suitable for use with this class. 
            Debug.Assert(CheckEntityConstraints());
        }

        /// <summary>
        /// the last exception that occurred while saving or deleting an entity
        /// </summary>
        public Exception LastException
        {
            get { return lastException; }
        }




        /// <summary>
        ///selection delegate expression, used for speeding up Load(int ID)
        /// needs to be implemented by Repository descendants as follows:
        ///
        /// protected override Expression<Func<SpecializedTEntityType, bool>> GetIDSelector(int ID)
        ///{
        ///    return (item) => item.ID == ID;
        ///}
        /// 
        /// SpecializedTEntityType represents the given entity's type
        /// and item.ID represents the entity's unique ID property
        /// 
        /// </summary>
        protected abstract Expression<Func<TEntityType, bool>> GetIDSelector(int ID);


        /// <summary>
        /// creates a new datacontext and loads the entity with the given unique ID
        /// </summary>
        /// <param name="ID">the unique entity ID</param>
        /// <returns>the entity if the ID exists, null otherwise</returns>
        public TEntityType Load(int ID)
        {
            DataContext Context = CreateContext();
            return Load(ID, Context);
        }

        /// <summary>
        /// loads the entity with the given unique ID from the given context
        /// </summary>
        /// <param name="ID">the unique entity ID</param>
        /// <param name="context">the datacontext</param>
        /// <returns>the entity if the ID exists, null otherwise</returns>
        protected TEntityType Load(int ID, DataContext context)
        {
            if (ID == 0)
            {
                return null;
            }
            return GetEntityTable(context).Single(GetIDSelector(ID));
        }

        /// <summary>
        /// Update or insert the Linq entity to the database,
        /// ignoring child entities
        /// If there is a version attribute, it will be refreshed after performing the Save operation. 
        /// If the Entity is new, the ID attribute will also be updated accordingly. 
        /// </summary>
        /// <returns>true on success, false otherwise</returns>
        public virtual bool Save(TEntityType ToSave)
        {
            return ExecuteDatabaseOperation(ToSave, OpMode.Save, false);
        }

        /// <summary>
        /// Updates or inserts the Linq entity into the database,
        /// Child entities are saved recursively
        /// If there is a version attribute, it will be refreshed after performing the Save operation. 
        /// If the Entity is new, the ID attribute will also be updated accordingly. 
        /// CAUTION: ID (and version if applicable) attribute(s) are only updated for the root entity, not on the associated child entities. 
        /// If those are in any way relevant, you need to reload the 
        /// </summary>
        /// <returns>true on success, false otherwise</returns>
        public virtual bool SaveRecursively(TEntityType ToSave)
        {
            return ExecuteDatabaseOperation(ToSave, OpMode.Save, true);
        }

        /// <summary>
        ///  Deletes the given Linq entity, ignoring child entities
        /// </summary>
        /// <returns>True on success, false otherwise</returns>
        public virtual bool Delete(TEntityType ToDelete)
        {
            return ExecuteDatabaseOperation(ToDelete, OpMode.Delete, false);
        }

        /// <summary>
        ///  Deletes the given Linq entity 
        ///  All child entities are also deleted
        /// </summary>
        /// <returns>True on success, false otherwise</returns>
        public virtual bool DeleteRecursively(TEntityType ToDelete)
        {
            return ExecuteDatabaseOperation(ToDelete, OpMode.Delete, true);
        }

        /// <summary>
        /// Deletes the Linq entity with the given ID
        /// Child Entities are not deleted
        /// </summary>        
        /// <returns>true on success, false otherwise</returns>
        public bool Delete(int ID)
        {
            return Delete(Load(ID));
        }


        /// <summary>
        /// Deletes the Linq entity with the given ID
        /// All preloaded child entities are also deleted
        /// </summary>        
        /// <returns>true on success, false otherwise</returns>
        public bool DeleteRecursively(int ID)
        {
            return DeleteRecursively(Load(ID));
        }

        /// <summary>
        /// Convenience function, returns all entities.
        /// 
        /// </summary>
        /// <returns>an IQuerable containing entities of type T</returns>
        public IQueryable<TEntityType> LoadAll()
        {
            return GetEntityTable(CreateContext());
        }

        public List<TEntityType> LoadWhere(Func<TEntityType, bool> predicate)
        {
            return GetEntityTable(CreateContext(),predicate);
        }

        #region Internal and helper methods

        private Exception lastException;

        /// <summary>
        /// Save / Insert / Delete the given Linq entity depending on the given OperationMode  
        /// </summary>
        /// <returns>true on success, false otherwise</returns>
        private bool ExecuteDatabaseOperation(TEntityType theEntity, OpMode OperationMode, bool Recursively)
        {
            using (DataContext context = CreateContext())
            {
                try
                {
                    //make sure the entity is not attached to an old datacontext 
                    TEntityType DetachedEntity = EntityDetacher<TEntityType>.Detach(theEntity);
                    Table<TEntityType> entityTable = context.GetTable<TEntityType>();

                    //for some unknown reason attaching the entity before deleting it is only necessary
                    //on the topmost entity, but not on the child entities
                    if (OperationMode == OpMode.Delete)
                    {
                        entityTable.Attach(DetachedEntity, true);
                    }

                    IterateEntity(DetachedEntity, context, entityTable, OperationMode, Recursively);

                    context.SubmitChanges();

                    //for save operations, update ID and version attributes for the entity
                    if (OperationMode == OpMode.Save)
                    {
                        PropertyInfo IDPropertyInfo =
                            theEntity.GetType().GetProperty(
                                context.Mapping.GetTable(typeof(TEntityType)).RowType.IdentityMembers[0].Name);
                        IDPropertyInfo.SetValue(theEntity, IDPropertyInfo.GetValue(DetachedEntity, null), null);

                        if (HasVersionProperty(context))
                        {
                            PropertyInfo VersionPropertyInfo =
                                theEntity.GetType().GetProperty(GetEntityVersionFieldName(context));
                            VersionPropertyInfo.SetValue(theEntity, VersionPropertyInfo.GetValue(DetachedEntity, null), null);
                        }

                    }
                }

                catch (Exception ex)
                {
                    SetException(ex, context);
                    return false;
                }
                return true;
            }
        }




        /// <summary>
        /// Save / Insert / Delete the contents of the given EntitySet
        /// </summary>
        internal void IterateEntitySet(object Set, DataContext context, OpMode OperationMode, bool Recursively)
        {
            Table<TEntityType> entityTable = GetEntityTable(context);
            foreach (TEntityType NextEntity in (EntitySet<TEntityType>)Set)
            {
                IterateEntity(NextEntity, context, entityTable, OperationMode, Recursively);
            }
        }


        /// <summary>
        /// Save / Insert / Delete the given Linq entity depending on the given OperationMode  
        /// </summary>
        /// <returns>true on success, false otherwise</returns>
        private void IterateEntity(TEntityType theEntity, DataContext context, Table<TEntityType> EntityTable, OpMode OperationMode, bool Recursively)
        {
            Debug.Assert(HasValidVersionProperty(theEntity, context));

            if (Recursively)
            {
                foreach (MetaAssociation association in context.Mapping.GetMetaType(typeof(TEntityType)).Associations)
                {
                    //only 1:n child entitites are which have been loaded are saved 
                    //check for 1:n relationship
                    if (association.IsMany && association.ThisKeyIsPrimaryKey)
                    {
                        PropertyInfo AssociationProperty = theEntity.GetType().GetProperty(association.ThisMember.Name);
                        //make sure there is at least one child entity to save
                        if (AssociationProperty.PropertyType.Name == "EntitySet`1")
                        {
                            //save the associated child entities
                            try
                            {
                                object Repository = association.OtherType.Type.GetMethod("CreateRepository").Invoke(null, null);
                                Repository.GetType().GetMethod("IterateEntitySet",
                                                             BindingFlags.NonPublic | BindingFlags.Instance).Invoke(
                                    Repository,
                                    new object[4]
                                    {
                                        AssociationProperty.GetValue(theEntity, null),
                                        context,
                                        OperationMode,
                                        Recursively
                                    }
                                    );
                            }
                            catch (System.Reflection.TargetInvocationException e)
                            {
                                throw (e.InnerException);
                            }
                        }
                    }
                }
            }

            switch (OperationMode)
            {
                case OpMode.Save:
                    if (IsNew(theEntity, context))
                    {
                        EntityTable.InsertOnSubmit(theEntity);
                    }
                    else
                    {
                        try
                        {
                            EntityTable.Attach(theEntity, true);
                        }
                        catch (Exception ex)
                        {
                            Debug.Write("e:" + ex.Message);
                        }
                        
                    }
                    break;
                case OpMode.Delete:
                    try
                    {
                        EntityTable.DeleteOnSubmit(theEntity);
                    }
                    catch (Exception test)
                    {
                        Debug.Write("e:" + test.Message);
                    }
                    break;
            }


        }


        /// <summary>
        /// there are two constraints on the entity types that this Repositorybase is used with:
        /// - All entities must have a unique ID property
        /// - Each entity must  must implement the CreateRepository method which returns a concrete RepositoryBase descendant that matches the entity type
        /// this method checks all three constraints
        /// the checks are only carried out in when the application runs in debug mode
        /// </summary>
        private bool CheckEntityConstraints()
        {
            DataContext context = CreateContext();

            //a version attribute is not required, but advisable for speeding up 
            //save and delete operations
            if (HasVersionProperty(context))
            {
                Debug.WriteLine("Warning: \"" +
                                                  typeof(TEntityType).Name +
                                                  "\" entity type does not have a version property. You might want to add a version column to speed up Saving and Deleting of \"" +
                                                  typeof(TEntityType).Name +
                                                  "\" entities");
            }

            //make sure that TEntityType has a unique ID property
            if (context.Mapping.GetTable(typeof(TEntityType)).RowType.IdentityMembers.Count == 0)
            {
                throw new NotImplementedException("\"" +
                                                  typeof(TEntityType).Name +
                                                  "\" entity type does not have a unique ID property");
            }

            /// make sure that all child linq entities of TEntityType implement a suitable "CreateRepository" Method 
            foreach (MetaAssociation association in context.Mapping.GetMetaType(typeof(TEntityType)).Associations)
            {
                if (association.OtherType.Type.GetMethod("CreateRepository") == null)
                {
                    throw new NotImplementedException("\"" + association.OtherType.Type.Name +
                                                      "\" entity type does not implement a RepositoryBase<SpecializedEntityType,DataClassesDataContext> CreateRepository() method.");
                }
            }
            return true;
        }

        private static bool HasVersionProperty(DataContext context)
        {
            return context.Mapping.GetTable(typeof(TEntityType)).RowType.VersionMember != null;
        }

        /// <summary>
        /// only new Linq entities are allowed to have a null version property. 
        /// if this is not the case then the version propery has probably gone lost while displaying the entity in a databound control
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        private bool HasValidVersionProperty(TEntityType Entity, DataContext context)
        {

            if (
                HasVersionProperty(context)
                ) if (
                 !IsNew(Entity, context)
                 && Entity.GetType().GetProperty(GetEntityVersionFieldName(context)).GetValue(Entity, null) == null)
                {
                    throw new ApplicationException(Entity.GetType().Name +
                                                   " has a non-zero identity property, but a null version. Check your databound controls to make sure the version attribute is retained.");
                }

            return true;
        }


        private bool IsNew(TEntityType Entity, DataContext context)
        {
            return (int)Entity.GetType().GetProperty(context.Mapping.GetTable(typeof(TEntityType)).RowType.IdentityMembers[0].Name).GetValue(Entity, null) == 0;
        }

        private Table<TEntityType> GetEntityTable(DataContext context)
        {
            return (Table<TEntityType>)context.GetTable(typeof(TEntityType));
        }

        private List<TEntityType> GetEntityTable(DataContext context, Func<TEntityType, bool> predicate)
        {
            return context.GetTable<TEntityType>().Where(predicate).ToList<TEntityType>();
        }

        private String GetEntityVersionFieldName(DataContext context)
        {
            Debug.Assert(HasVersionProperty(context));
            return context.Mapping.GetTable(typeof(TEntityType)).RowType.VersionMember.Name;
        }

        protected virtual TContextType CreateContext()
        {
            var context = new TContextType();

            //print the resulting SQL statements in the debug output console when the application is running in debug mode
            Debug.Assert(LogDataContextOutput(context));

            return context;
        }



        bool LogDataContextOutput(DataContext context)
        {
            context.Log = new DebuggerWriter();
            return true;
        }
        //TODO: optional rethrow outside of DAL
        private void SetException(Exception Exception, DataContext context)
        {
            lastException = Exception;
            context.Log.Write(Exception.ToString());
        }

        /// <summary>
        /// Saving and Deleting entities works in a very similar fashion, so I am using using a 
        /// template function with different opmode parameters for both operations
        /// </summary>
        internal enum OpMode
        {
            Delete,
            Save
        } ;

        #endregion
    }
}
