using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Marvellent.Utility
{
    public class SerializeDeserialize<T>
    {
        public SerializeDeserialize()
        {
            //Default constructor
        }

        public static string ToJSONString(T o)
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(T));
            string returnVal = string.Empty;
            using (MemoryStream ms = new MemoryStream())
            {
                js.WriteObject(ms, o);
                ms.Position = 0;
                using (StreamReader sr = new StreamReader(ms))
                {
                    returnVal = sr.ReadToEnd();
                }
            }
            return returnVal;
        }

        public static T FromJSONString(string json)
        {
            T o;
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(T));
                o = (T)deserializer.ReadObject(ms);
            }
            return o;
        }
    }
}
