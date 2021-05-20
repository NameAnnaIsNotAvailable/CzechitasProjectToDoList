using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace úkolovník
{
    public class ProgramManagemant 
    {

        string theEnd = "Konec";
        public string Commands = @"
            1. Chci vložit nový úkol         5. Chci upravit úkol:
            2. Chci dokončit úkol            6. Chci vzhledat úkol 
            3. Chci odstranit úkol           7. Ukončit program
            4. Chci zobrazit úkoly
           "; 
        public bool EndApp { get; set; }
        public string ShowMenu()
        {
            return Commands;
        }


        public bool FinishApp(string end)
        {
            EndApp = end == theEnd ? true : false;
            return EndApp;
        }


        public void FinishApp()
        {
            Environment.Exit(0);
        }
   

    }
}
