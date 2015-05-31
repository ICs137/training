﻿using System;
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

      
        string[] punctuationSeparators = new string[] { " '", ",", ".", "!", "?","\"", ":", ";", "(", ")", "—", "' "," " };

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

       public void ReadText() //read file and parse text into lines
       {

           ReadText(objFile.FilePath);

       }


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
                                 Words itemWords = new Words(lineNumber + 1) { WorrdsValue = word };

                                itemWords[lineNumber] = 1;
                              
                                wordsCountDict.Add(word,  itemWords);
                             }
                        else
                             {
                                 wordsCountDict[word][lineNumber]++;
                             }
                   }
                    lineNumber--;
                }
        }
       */

  //------------------------------------------------------------------------------------------------------------------------
       public void GetOutputList()
        {
               string str = string.Empty;
               str = String.Concat(str, "\n");

               int textSize = lines.Count;

               outputList.Add(String.Format("the file {0} contains{1}",objFile.FileName,str));
              

               foreach (var alphabeticalGroup in wordsCountDict.OrderBy(x => x.Key).GroupBy(x => x.Key[0]))
                   {

                          outputList.Add(String.Format(" {0}       -={1}=-", str, alphabeticalGroup.Key.ToString().ToUpper()));
                    

                     foreach (var  iteamGroup in alphabeticalGroup )

                          {
                              outputList.Add(iteamGroup.Value.WordInfo(pageSize,textSize));
                             
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
