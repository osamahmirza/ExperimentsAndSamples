using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Text;
using System.Xml.Linq;
using System.Net;
using Codicode;

namespace ANWO.Utility
{
    public static class UtilityFunctions
    {
        public static bool IsInt(string text)
        {
            int num;
            bool isNumeric = int.TryParse(text, out num);
            return isNumeric;
        }

        public static System.Boolean IsNumeric(System.Object Expression)
        {
            if (Expression == null || Expression is DateTime)
                return false;

            if (Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is Decimal || Expression is Single || Expression is Double || Expression is Boolean)
                return true;

            try
            {
                if (Expression is string)
                    Double.Parse(Expression as string);
                else
                    Double.Parse(Expression.ToString());
                return true;
            }
            catch // just dismiss errors but return false
            {
                return false;
            } 
        }

        //Check valid URL
        public static bool UrlExists(string url)
        {
            try
            {
                //Creating the HttpWebRequest
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //Setting the Request method HEAD, you can also use GET too.
                request.Method = "HEAD";
                //Getting the Web Response.
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //Returns TRUE if the Status code == 200
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                //Any exception will returns false.
                return false;
            }
        }
        
        //Check valid web address
        public static bool EmailAddressExists(string emailAddress, string fromEmailAddress)
        {
            EmailValidator ev = new EmailValidator();
            try
            {
                //Set the sender email (for smtp identification)
                ev.Mail_From = fromEmailAddress;
                
                //check if the email address is valid and really exists
                string errMsg = ev.Check_MailBox_Error(emailAddress);

                if (errMsg == "")
                    return true;
                else
                    return false;
            }
            catch { return false; }

            
        }

        #region Serialize / Deserialize

        public static string SerializeToXML<T>(T obj)
        {
            string xmlstring = string.Empty;

            XmlSerializer x = new XmlSerializer(obj.GetType());
            MemoryStream memoryStream = new MemoryStream();
            StreamWriter writer = new StreamWriter(memoryStream);

            x.Serialize(writer, obj);
            memoryStream = (MemoryStream)writer.BaseStream;
            xmlstring = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());

            writer.Close();
            memoryStream.Dispose();

            return xmlstring;
        }

        public static object DeserializeObject<T>(string pXmlizedString)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(pXmlizedString));
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            return xs.Deserialize(memoryStream);
        }

        private static Byte[] StringToUTF8ByteArray(String pXmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }

        #endregion

    }
}