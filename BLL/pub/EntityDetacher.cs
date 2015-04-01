using System;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;

namespace BLL.pub
{

    public class EntityDetacher<T>
    {
        //detach a LINQ entity from it's previous datacontext by serialization / deserialization
        static public T Detach(T item)
        {
            string detachedProp = Serialize(item);
            return (T)Deserialize(typeof(T), detachedProp);
        }

        static private string Serialize(object value)
        {
            if (value.GetType() == typeof(string))
                return value.ToString();

            var stringWriter = new StringWriter();
            using (XmlWriter writer = XmlWriter.Create(stringWriter))
            {
                var serializer = new
                    DataContractSerializer(value.GetType());
                serializer.WriteObject(writer, value);
            }

            return stringWriter.ToString();
        }

        static private object Deserialize(Type type, string serializedValue)
        {
            if (type == typeof(string))
                return serializedValue;

            using (var stringReader = new StringReader(serializedValue))
            {
                using (XmlReader reader = XmlReader.Create(stringReader))
                {
                    var serializer =
                        new DataContractSerializer((type));

                    object deserializedValue = serializer.ReadObject(reader);

                    return deserializedValue;
                }
            }
        }
    }
}
