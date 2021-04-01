using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace VerManagerLibrary
{
    public class ErrorClass
    {
        public string ErrorID { get
            {
                DateTime today = DateTime.Today;
                Regex pattern = new Regex("[.:/ ]");
                string IDValue = Environment.UserName + "_" + today.Date.ToString("MM_dd_yyyy") + "_" + errorIndex.ToString();
                return IDValue;
            }
        }
        public string Comment { get; set; }
        private int errorIndex = 1;
        public ErrorClass (string comment)
        {
            this.Comment = comment;
        }

        public Dictionary<string, DocumentClass> FilesWithErrorDict = new Dictionary<string, DocumentClass>();

    }
}
