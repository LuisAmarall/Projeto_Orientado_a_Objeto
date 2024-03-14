using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Orientado_a_Objeto
{
    internal static class Serialization
    {
        //Attributes to serialization of data base
        private static DataContractSerializer serializer = new DataContractSerializer(typeof(DateBase));

        //Method to bengin the serialization of the file
        public static void serialization(string pFileWay, DateBase pDateBase)
        {
            //Method of serializer
            XmlWriterSettings settings = new XmlWriterSettings { Indent = true};
            StringBuilder builder = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(builder, settings);
            serializer.WriteObject(writer, pDateBase);
            writer.Flush();
            string serializerObject = builder.ToString();

            //Method to create of the File Way
            FileStream xmlFile = File.Create(pFileWay);
            xmlFile.Close();
            File.WriteAllText(pFileWay, serializerObject);
            writer.Close();
        }

        //Method to deserializer the object
        public static DateBase deserialization(string pFileWay)
        {
            try
            {
                if (File.Exists(pFileWay))
                {
                    string objectDeserialization = File.ReadAllText(pFileWay);
                    StringReader reader = new StringReader(objectDeserialization);
                    XmlReader xmlReader = XmlReader.Create(reader);
                    DateBase dateBaseTemporary = (DateBase)serializer.ReadObject(xmlReader);
                    return dateBaseTemporary;
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
