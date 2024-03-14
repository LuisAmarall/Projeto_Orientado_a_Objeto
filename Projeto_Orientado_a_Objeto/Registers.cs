using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;
using System.IO; 

namespace Projeto_Orientado_a_Objeto
{
    [DataContract]
    internal class Registers
    {
        //Attributes for registration storage
        [DataMember]
        private string name;
        [DataMember]
        private string doc;
        [DataMember]
        private DateTime dateOfBirth;
        [DataMember]
        private UInt32 houseNumber;

        //Properties for attributes manipulation
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Doc
        {
            get { return doc; }
            set { doc = value; }
        }
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }
        public UInt32 HouseNumber
        {
            get { return houseNumber; }
            set { houseNumber = value; }
        }

        //Method constructor
        public Registers(string pName, string pDoc, DateTime pDateOfBirth, UInt32 pHouseNumber)
        {
            name = pName;
            doc = pDoc;
            dateOfBirth = pDateOfBirth;
            houseNumber = pHouseNumber;
        }
    }
}
