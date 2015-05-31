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

        const int pageSize =42;   // number of lines per page

      
        string[] punctuationSeparators = new string[] { " '", ",", ".", "!", "?","\"", ":", ";", "(", ")", "—", "' "," ","^" };

        IDictionary<string, Words> wordsCountDict = new Dictionary<string, Words>() ;


        FileManager objFile = new FileManager();


        List<string> outputList = new List<string>();

        public List<string> OutputList { get { return outputList; } }


        List<string> lines = new List<string>();

        public List<string> Lines { get { return lines; } }

       


   //------------------------------------------------------------------------------------------------------------------------
       
       public void ReadText() //read file and parse text into lines
        {
            
                try
                {
                    using (StreamReader streamreader = new StreamReader(objFile.FilePath, Encoding.Default))
                     {
                            while (streamreader.Peek() >=0)
                              {
                                 lines.Add(streamreader.ReadLine().ToLower());
                              }
                     }
                }
                catch (Exception except)
                {
                    Console.WriteLine("The process failed: {0}", except.Message);
                }

       }

       

// ver 2
       public void CreateConcordance()  // creating the dictionary that contains information about  words: where key=this word
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
                    
                       wordsCountDict.Add(word, new Words(lineNumber) { WorrdsValue = word });
                       
                   }
                   else
                   {
                       wordsCountDict[word].WordCount.Add(lineNumber);
                   }
               }
               lineNumber++;
           }
       }




       /* ver. 1
           //------------------------------------------------------------------------------------------------------------------------
       
   
         public void CreateConcordance()
            {

                int lineNumber = Lines.Count();
                foreach (var line in Lines.Reverse())
                   {
                        string[] onlyWords = line.Split(punctuationSeparators, StringSplitOptions.RemoveEmptyEntries);

                        foreach (var word in onlyWords)
                        {
                            if (!Char.IsLetter(word[0]))
                                 { continue; }

                            if (!wordsCountDict.ContainsKey(word))
                                 {
                                     Words itemWords = new Words(lineNumber + 1) { WorrdsValue = word, Total=1};

                                    itemWords[lineNumber] = 1;
                              
                                    wordsCountDict.Add(word,  itemWords);
                                 }
                            else
                                 {
                                     wordsCountDict[word][lineNumber]++;
                                     wordsCountDict[word].Total++;
                                 }
                       }
                        lineNumber--;
                    }
            }
       //    */

       //------------------------------------------------------------------------------------------------------------------------
       public void GetOutputList()
        {
              
       //  int textSize = lines.Count; // ver. 1

               outputList.Add(String.Format("the file {0} contains \n", objFile.FileName));
              

               foreach (var alphabeticalGroup in wordsCountDict.OrderBy(x => x.Key).GroupBy(x => x.Key[0]))
                   {

                       outputList.Add(String.Format("\n       -={0}=-", alphabeticalGroup.Key.ToString().ToUpper()));
                    

                     foreach (var  iteamGroup in alphabeticalGroup )

                          {
                              outputList.Add(iteamGroup.Value.WordInfo(pageSize));
                             
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
