using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concordance2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the file name");
            IFileManager objFile = new FileManager(Console.ReadLine());
            Concordance concordance = new Concordance();
            concordance.CreateConcordance(objFile.GetContent());
            concordance.GetOutputContent();
            objFile.SaveContent(concordance.OutputContent);
       
        }
    }
}
