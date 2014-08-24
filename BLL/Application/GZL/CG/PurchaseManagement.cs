using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Application.GZL.CG
{
    public class PurchaseManagement
    {
        public static List<v_GZL_MyApplyItem> getMyApplyItems(int userid,String itemType)
        {
            using(DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.v_GZL_MyApplyItem.Where(i => i.ApplyUserId == userid && i.ItemType == itemType).OrderByDescending(i=>i.ItemId).ToList();
            }

        }

        public static List<v_GZL_MyApplyItem> getApplyItemsByCondition(int indexPg,int pgSize,ref pub.PagerTClass pageT,String deptId="",String itemName="",String startTime="",String endTime="")
        {
            IEnumerable<v_GZL_MyApplyItem> items;
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                items = dc.v_GZL_MyApplyItem;
                if (!String.IsNullOrEmpty(deptId))
                    items = items.Where(i => i.deptId == Convert.ToInt16(deptId));
                if (!String.IsNullOrEmpty(itemName))
                    items = items.Where(i => i.ItemName.Contains(itemName));
                if (!String.IsNullOrEmpty(startTime) && !String.IsNullOrEmpty(endTime))
                    items = items.Where(i => i.ApplyDate >= Convert.ToDateTime(startTime) && i.ApplyDate <= Convert.ToDateTime(endTime));
                else if (!String.IsNullOrEmpty(startTime))
                    items = items.Where(i => i.ApplyDate >= Convert.ToDateTime(startTime));
                items = pageT.ShowPage(items, indexPg, pgSize);
                return items.ToList();

            }
        }
       
        public static bool saveFormReason(String itemid,int userid,String reason)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                t_GZL_Item item = dc.t_GZL_Item.Where(i => i.ItemId == Convert.ToInt32(itemid)).Single();
                var forms = dc.t_Form_Purchase.Where(f => f.itemGuid == item.itemGuid);
                if(forms.Count() == 0)
                {
                    t_Form_Purchase form = new t_Form_Purchase();
                    form.applyDept = item.deptId;
                    form.applyUserId = userid;
                    form.applyDate = item.ApplyDate;
                    form.applyReason = reason;
                    dc.t_Form_Purchase.InsertOnSubmit(form);
                }else
                {
                    t_Form_Purchase form = dc.t_Form_Purchase.Where(f => f.itemGuid == item.itemGuid).Single();
                    form.applyReason = reason;
                }
                dc.SubmitChanges();
                return true;
            }
        }
        public static int getPurchaseFormCountByItemGuid(Guid uid)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.t_Form_Purchase.Where(f => f.itemGuid == uid).Count();
            }
        }
        public static t_Form_Purchase getPurchaseFormByItemGuid(Guid uid)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.t_Form_Purchase.Where(f => f.itemGuid == uid).Single();
            }
        }
        public static bool updateFormReason(t_Form_Purchase form)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                t_Form_Purchase f = dc.t_Form_Purchase.Where(t => t.formId == form.formId).Single();
                f.applyReason = form.applyReason;
                dc.SubmitChanges();
                return true;
            }
        }

        public static bool deleteFormPurchaseItemById(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                t_Form_Purchase_Items item =  dc.t_Form_Purchase_Items.Where(f => f.Id == id).Single();
                t_Form_Purchase form = dc.t_Form_Purchase.Where(f => f.formId == item.formId).Single();
                form.totalPrice = form.totalPrice - item.totalPrice;
                dc.t_Form_Purchase_Items.DeleteOnSubmit(item);
                dc.SubmitChanges();
                return true;
            }
        }
        public static List<t_Form_Purchase_Items> getFormPurchaseItemsByFormId(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.t_Form_Purchase_Items.Where(p => p.formId == id).OrderBy(p=>p.sortId).ToList();
            }
        }

        public static bool createFormPurchase(t_Form_Purchase form)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                dc.t_Form_Purchase.InsertOnSubmit(form);
                dc.SubmitChanges();
                return true;
            }
        }

        public static bool insertFormPurchaseItems(t_Form_Purchase_Items items,t_Form_Purchase form)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                t_Form_Purchase f = dc.t_Form_Purchase.Where(u => u.formId == form.formId).Single();
                f.totalPrice = f.totalPrice + items.totalPrice;
                dc.t_Form_Purchase_Items.InsertOnSubmit(items);
                dc.SubmitChanges();
                return true;
            }
        }

        public static bool applyItem(String itemid,String username,int actorUserId)
        {
            try
            {
                using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
                {
                    t_GZL_Item item = dc.t_GZL_Item.Where(i => i.ItemId == Convert.ToInt32(itemid)).Single();
                    t_GZL_TaskList task = dc.t_GZL_TaskList.Where(t => t.itemGuid == item.itemGuid).Single();
                    t_GZL_Actor actor = dc.t_GZL_Actor.Where(a => a.actorId == task.actorId).Single();

                   
                    int sortNo = (int)actor.sortNo;
                    var actor_next = dc.t_GZL_Actor.Where(a => a.routId == actor.routId && a.sortNo == sortNo + 1);
                    if (actor_next.Count() != 0)//还有下一步流程
                    {
                        task.actorId = actor_next.Single().actorId;
                        item.State = "待审批"; //修改任务状态
                        t_GZL_TaskHistory history = new t_GZL_TaskHistory();//插入历史记录
                        history.actorId = actor.actorId;
                        history.createDate = System.DateTime.Now;
                        history.itemGuid = item.itemGuid;
                        history.itemId = item.ItemId;
                        history.operatorName = username;
                        history.operatorUserId = item.ApplyUserId;
                        history.action = "送审";
                        dc.t_GZL_TaskHistory.InsertOnSubmit(history);

                        var has_actuser = dc.t_GZL_actorUser.Where(u => u.actorId == task.actorId && u.itemGuid == item.itemGuid && u.operateUserId == actorUserId && u.taskId == task.taskId);
                        if (has_actuser != null && has_actuser.Count() > 0)
                        { }
                        else//第一次申请则插入执行人，否则用原有
                        {
                            t_GZL_actorUser actUser = new t_GZL_actorUser();//插入下一步执行的人
                            actUser.actorId = task.actorId;
                            actUser.itemGuid = item.itemGuid;
                            actUser.itemId = item.ItemId;
                            actUser.operateUserId = actorUserId;
                            actUser.taskId = task.taskId;
                            dc.t_GZL_actorUser.InsertOnSubmit(actUser);
                        }

                        t_User_Task userTask = new t_User_Task();//插入下一步执行人的任务，用于提醒
                        userTask.description = "您有一个待审批的采购项目";
                        userTask.isClick = false;
                        userTask.url = "/Application/GZL/CG/ApplyApprove.aspx";
                        userTask.createtime = DateTime.Now;
                        userTask.userid = actorUserId;
                        dc.t_User_Task.InsertOnSubmit(userTask);

                        dc.SubmitChanges();
                        return true;
                    }
                    else
                        return false;
                }
            }catch (Exception ex)
            {
                throw new Exception("送审错误："+ ex.Message);
            }
        }
        public static int getTaskActorUserId(String itemid)
        {
            using(DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var list = dc.v_GZL_MyTaskList.Where(t => t.itemGuid == dc.t_GZL_Item.Where(u => u.ItemId == Convert.ToInt32(itemid)).Single().itemGuid);
                if (list.Count() > 0)
                    return (int)list.Single().operateUserId;
                else
                    return -1;
            }
        }

        public static List<v_GZL_History> getPurchaseHistoryByItemGuid(Guid guid)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.v_GZL_History.Where(h => h.itemGuid == guid).ToList();
            }
        }


    }
}
