using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concordance
{
        class FileManager
    {

       public string FileName { get; set; }

       public string FilePath { get { return "../../" + FileName; } }

       public void RequestOpenFile()
           {
               Console.WriteLine("Enter the file name");
               FileName = Console.ReadLine();
           }
       
       public FileManager ()
           {
               RequestOpenFile();
           }

    }
}
