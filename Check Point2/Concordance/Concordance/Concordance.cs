using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Concordance
{
   public class Concordance
    {

        const int pageSize = 40;   // number of lines per page

        char[] punctuationSeparators = new char[] { ' ', ',', '.', '!', '?', ':', ';', '(', ')', '—','"'};

        IDictionary<string, Words> wordsCountDict = new Dictionary<string, Words>() ;


        FileManager objFile = new FileManager();

       
        ICollection<string> outputList = new List<string>();

        public ICollection<string> OutputList { get { return outputList; } }

       
        ICollection<string> lines = new List<string>();

        public ICollection<string> Lines { get { return lines; } }

        public int LinesCount {get {return  lines.Count;}}


   //------------------------------------------------------------------------------------------------------------------------
       
       public void ReadText(string filePath) //read file and parse text into lines
        {
            
                try
                {
                    using (StreamReader streamreader = new StreamReader(filePath, Encoding.Default))
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

       public void ReadText() //read file and parse text into lines
       {

           ReadText(objFile.FilePath);

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
       public void GetOutputList()
        {
               string str = string.Empty;
               str = String.Concat(str, "\n");

               outputList.Add(String.Format("the file {0} contains{1}",objFile.FileName,str));
              

               foreach (var alphabeticalGroup in wordsCountDict.OrderBy(x => x.Key).GroupBy(x => x.Key[0]))
                   {

                     string  capitalLetter= alphabeticalGroup.Key.ToString().ToUpper();

                     outputList.Add(String.Format(" {0} -={1}=-",str, capitalLetter[0]));
                    

                     foreach (var  group in alphabeticalGroup )

                          {
                            
                               string lineNuber= string.Empty;

                               for (int i = 0; i <  group.Value.WordCount; i++)
                               {

                                   if (i != 0)
                                     {
                                          if ( group.Value[i]!=0 )

                                          {
                                              lineNuber = String.Concat(lineNuber, String.Format("{0}", i.ToString().PadLeft(3)));
                                         
                                          }
                                                
                                      }

                               }
                               outputList.Add(String.Format("  {0} total ={1}:{2} ", group.Key.PadRight(21, '.'), group.Value[0].ToString().PadLeft(3), lineNuber));
                               
                             
                          }
                                           

                   }

            }
   //------------------------------------------------------------------------------------------------------------------------
       

       public void ToConsole() 

           {

                foreach (string  str in outputList  )
                { Console.WriteLine(str); }

           }

   //------------------------------------------------------------------------------------------------------------------------

       public void ToFile()


           {

                objFile.ToFile(OutputList);

           }
      





       

    }
}
