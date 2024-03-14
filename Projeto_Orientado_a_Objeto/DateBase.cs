using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Projeto_Orientado_a_Objeto
{
    [DataContract]
    internal class DateBase
    {
        //Attributes for date base storege
        [DataMember]
        private List<Registers>DateList;
        private string fileWayToDateBase;

        //Method for registering people
        public void putPeople(Registers pPut)
        {
            DateList.Add(pPut);
            Serialization.serialization(fileWayToDateBase, this);
        }

        //Method to search user in list
        public List<Registers> searchInList(string pSearch)
        {
            List<Registers> TemporaryList = DateList.Where(x=>x.Doc == pSearch).ToList();
            if (TemporaryList.Count > 0)
                return TemporaryList;
            else
                return null;
        }

        //Method to remove user in list
        public List<Registers> removeInList(string pRemove)
        {
            List<Registers> TemporaryList = DateList.Where(x => x.Doc == pRemove).ToList();
            if (TemporaryList.Count > 0)
            {
                foreach (Registers person in TemporaryList)
                {
                    DateList.Remove(person);
                }
                return TemporaryList;
            }
            else
                return null;
        }

        //Method constructor
        public DateBase(string pFileWayToDateBase)
        {
            fileWayToDateBase = pFileWayToDateBase;
            DateBase dateBaseTemporary = Serialization.deserialization(fileWayToDateBase);
            if (dateBaseTemporary != null)
            {
                DateList = dateBaseTemporary.DateList;
            }
            else
                DateList = new List<Registers>();
        }
    }
}
