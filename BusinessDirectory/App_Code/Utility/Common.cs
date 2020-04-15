using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Data;
using System.ComponentModel;
using System.Configuration;

namespace GoProGo.Utility
{
    public static class Common
    {

        public static string SerializeXml<T>(T pObject)
        {
            MemoryStream memoryStream = new MemoryStream();
            try
            {
                string XmlizedString = null;
                XmlSerializer xs = new XmlSerializer(typeof(T));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

                xs.Serialize(xmlTextWriter, pObject);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
                return XmlizedString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                memoryStream.Close();
                memoryStream.Dispose();
            }
        }

        public static T DeserializeXml<T>(string pXmlizedString)
        {
            MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(pXmlizedString)); 
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                return (T)xs.Deserialize(memoryStream);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                memoryStream.Close();
                memoryStream.Dispose();
            }
        }


        private static string UTF8ByteArrayToString(byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            string constructedString = encoding.GetString(characters);
            return (constructedString);
        }

        private static byte[] StringToUTF8ByteArray(string pXmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }

        //Resize picture
        public static System.Drawing.Image ResizePic(string filePath, ImageFormat imgFormat, int aspectSize)
        {
            System.Drawing.Image origImage = System.Drawing.Image.FromFile(filePath);

            float WidthPer, HeightPer;
            int NewWidth, NewHeight;

            if (origImage.Width > origImage.Height)
            {
                NewWidth = aspectSize;
                WidthPer = (float)aspectSize / origImage.Width;
                NewHeight = Convert.ToInt32(origImage.Height * WidthPer);
            }
            else
            {
                NewHeight = aspectSize;
                HeightPer = (float)aspectSize / origImage.Height;
                NewWidth = Convert.ToInt32(origImage.Width * HeightPer);
            }
            System.Drawing.Image origThumbnail = new Bitmap(NewWidth, NewHeight, origImage.PixelFormat);
            Graphics oGraphic = Graphics.FromImage(origThumbnail);
            oGraphic.CompositingQuality = CompositingQuality.HighQuality;
            oGraphic.SmoothingMode = SmoothingMode.HighQuality;
            oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            Rectangle oRectangle = new Rectangle(0, 0, NewWidth, NewHeight);
            oGraphic.DrawImage(origImage, oRectangle);
            //origThumbnail.Save(filePath + @"\" + thumbFileName, imgFormat);
            origImage.Dispose();
            return origThumbnail;
        }

        //To convert a List into a datatable
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public static string MakeSearchCriteria(string criteria)
        {
            string searchEngineProximity = ConfigurationManager.AppSettings["SearchEngineProximity"].ToString();

            string str = criteria;
            string[] tokens = criteria.Split(new string[]{" "}, StringSplitOptions.RemoveEmptyEntries);
            
            StringBuilder interCriteria = new StringBuilder();
            for (int i = 0; i < tokens.Length; i++)
            {
                if (i < tokens.Length - 1)
                    interCriteria.Append("\"" + tokens[i] + "\" " + searchEngineProximity + " ");
                else
                    interCriteria.Append("\"" + tokens[i] + "\"");
            }
            return interCriteria.ToString();
        }
        
    }
}
