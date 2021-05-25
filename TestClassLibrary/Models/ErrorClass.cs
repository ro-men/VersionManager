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
        public string ErrorID { get; set; }
        public string Comment { get; set; }
        public void CreateErrorID()
        {
            DateTime today = DateTime.Today;
            Regex pattern = new Regex("[.:/ ]");
            string IDValue = Environment.UserName + "_" + today.Date.ToString("MM_dd_yyyy") + "_" + errorIndex.ToString();
            ErrorID = IDValue;          
        }

        private static int errorIndex = 1;

        public Dictionary<string, bool> CoreDocuments = new Dictionary<string, bool>(); //key -> DocumentClass_key; value -> STATUS: [True(Solved) // False(Unsolved)]
                                                                                        //izravno odabrani dokumenti kod kreiranja nove "greške"
        public Dictionary<string, bool> EditedDocuments = new Dictionary<string, bool>(); //key -> DocumentClass_key; value -> STATUS: [True(Solved) // False(Unsolved)]
                                                                                          //dokumenti identične nomenklature ili tipa koji sadrže istu potrebu za promjenom
        public Dictionary<string, bool> Siblings = new Dictionary<string, bool>(); //key -> DocumentClass_key; value -> STATUS: [True(Solved) // False(Unsolved)]
                                                                                   //dokumenti koju su izravno povezani rordoslovnim stablom sa "EditedDocuments" te su kao takvi zastarjeli usljed potrebe za prommjenom
    }
}
