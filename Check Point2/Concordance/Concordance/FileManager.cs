using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concordance
{
        class FileManager
    {
       public string SaveFilePath { get { return "../../"+ "Concord " + FileName; } }
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

       public void ToFile(ICollection<string> outputList)
       {
           try
           {
               using (StreamWriter swriter = new StreamWriter( SaveFilePath,false, Encoding.Default))
               {
                   foreach (var item in outputList)
                   {
                       swriter.WriteLine(item);
                   }


               }

               Console.WriteLine(String.Concat("file is  recorded" , SaveFilePath ));

           }
           catch (Exception ex)
           {
               Console.WriteLine(ex.Message);
           }
       }





    }
}
