using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concordance
{
  public  class Words

  {
        
        public string WorrdsValue {get;set;}

        Int16[] wordCount;

        public int WordCount { get { return wordCount.Length; } }

        public Words(int size)
            {
                wordCount = new Int16[size];
            }



        public Int16 this[int indexWordCount] 
            { 
            
                get
                    {
                      
                            return wordCount[indexWordCount];
                   
                    } 
            
                set 
                    {
                        if (indexWordCount > 0)
                        {
                            wordCount[indexWordCount] = value;

                            wordCount[0]++; // zero point to store information about the number of words in the text 

                        }
                                        
                    }
        
            }

        //-------------------------------- The method generates information about the word-------------------------------------------
        public string WordInfo(int pageSize, int textSize)
        {
            
          string wordInfo= string.Empty;

          wordInfo = String.Format("  {0} total = {1} \n\r", WorrdsValue.PadRight(18, '.'), wordCount[0]);
          int lineNumber = 1; ;
          int numberPage;

              numberPage = textSize / pageSize;

              if (textSize % pageSize > 0)
             {
                 numberPage++;
             }
           

            for (int i = 1; i <= numberPage; i++)  // iterate page
               {
                      string pagedInfo = string.Empty;
                      string lineInfo = string.Empty;
                            for (int j = 1; j <= pageSize; j++)  // iterate line
                                  {
                                      if (lineNumber >= WordCount)

                                          break;
                                
                                      if (wordCount[lineNumber] != 0)
                                      {

                                          lineInfo = String.Concat(lineInfo, String.Format(" {0}", j));

                                      }
                                      lineNumber++;

                                  }

                      if (lineInfo != string.Empty)
                          {

                              pagedInfo = String.Concat(pagedInfo, String.Format("Page  {0} : ({1})  \r\n", i, lineInfo ));

                              lineInfo = string.Empty;
                          }

                     if (pagedInfo != string.Empty)
                          {

                              wordInfo = String.Concat(wordInfo, pagedInfo);
                              pagedInfo = string.Empty;

                          }

                 
                }

           
          return wordInfo;

        }
     
    }
}
