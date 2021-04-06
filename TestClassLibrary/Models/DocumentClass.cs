﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INFITF;


namespace VerManagerLibrary
{
    public class DocumentClass
    {
        public DocumentClass(String fullName)
        {
            this.FullName = fullName;
            string[] Name = FullName.Split('\\');
            this.PartName = Name[Name.Length - 1];
        }
        public Dictionary<string, DocumentClass> ChildrenDict = new Dictionary<string, DocumentClass>();
        public Dictionary<string, DocumentClass> ParentsDict = new Dictionary<string, DocumentClass>();
        public Dictionary<string, ErrorClass> ErrorsDict = new Dictionary<string, ErrorClass>();
        public String Comment { get 
            {
                string comment = "";
                foreach(ErrorClass errorInstance in ErrorsDict.Values)
                {
                    comment = comment + "\n" + errorInstance.Comment;
                }

                return comment;
            } 
        }
        public Boolean Used { get { return this.ParentsDict.Count != 0; } }
        public Boolean HasChindren { get { return this.ChildrenDict.Count != 0; } }
        public String PartName { get; }
        public String FullName { get; }
           
        
        public void AdChild(DocumentClass documentClassInstance)
        {
            if (!ChildrenDict.ContainsKey(documentClassInstance.FullName))
            {
                this.ChildrenDict.Add(documentClassInstance.FullName, documentClassInstance);
            }
        }
        public void AdParent(DocumentClass documentClassInstance)
        {
            if (!ParentsDict.ContainsKey(documentClassInstance.FullName))
            {
                this.ParentsDict.Add(documentClassInstance.FullName, documentClassInstance);
            }
        }

        public void AdError(ErrorClass errorInstance)
        {
            if (!ErrorsDict.ContainsKey(errorInstance.ErrorID))
            {
                this.ErrorsDict.Add(errorInstance.ErrorID, errorInstance);
            }
        }
    }
}