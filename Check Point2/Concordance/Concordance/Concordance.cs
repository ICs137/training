using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Concordance
{
   public class Concordance
    {

        const int pageSize = 40;   // number of lines per page

        char[] punctuationSeparators = new char[] { ' ', ',', '.', '!', '?', ':', ';', '—', '(', ')' };

        IDictionary<string, Words> wordsCountDict = new Dictionary<string, Words>() ;


        FileManager objFile = new FileManager();


        ICollection<string> lines = new List<string>();

        public ICollection<string> Lines { get { return lines; } }

        public int LinesCount {get {return  lines.Count;}}

   //------------------------------------------------------------------------------------------------------------------------
       
       public void ReadText() //read file and parse text into lines
        {
            
                try
                {
                   using (StreamReader streamreader = new StreamReader(objFile.FilePath))
                     {
                            while (streamreader.Peek() > -1)
                              {
                                 lines.Add(streamreader.ReadLine().ToLower());
                              }
                     }
                }
                catch (Exception Except)
                {
                    Console.WriteLine("The process failed: {0}", Except.Message);
                }

       }

       
  //------------------------------------------------------------------------------------------------------------------------
        public void CreateConcordance()
        {

            int lineNumber = 1;
            foreach (var line in Lines)
               {
                    string[] onlyWords = line.Split(punctuationSeparators, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in onlyWords)
                    {
                        if (!Char.IsLetter(word[0]))
                             { continue; }

                        if (!wordsCountDict.ContainsKey(word))
                             {
                                 Words itemWords = new Words(LinesCount+1) { WorrdsValue = word };

                                itemWords[lineNumber] = 1;
                                wordsCountDict.Add(word,  itemWords);
                             }
                        else
                             {
                                 wordsCountDict[word][lineNumber]++;
                             }
                   }
                    lineNumber++;
                }
        }

  //------------------------------------------------------------------------------------------------------------------------
       public void ToConsole()
        {
          
               Console.WriteLine("the file {0} contains",objFile.FileName);

           foreach (var sortdict in wordsCountDict.OrderBy(x => x.Key))
           {
               
              Console.Write( sortdict.Key);
              for (int i = 0; i < sortdict.Value.WordCount; i++)
                  {
                      if (i == 0)

                          { 
                              Console.Write(" quantity = {0}  lines ", sortdict.Value[i]);
                          }
                      else 
                          {
                              if ( sortdict.Value[i]!=0 )
                              {
                                  Console.Write("  {0}", i % pageSize);

                              }
                                    
                          }

                  }

              Console.WriteLine();
              Console.WriteLine();

           }


        }

       

    }
}
