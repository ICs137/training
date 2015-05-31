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

  // ver 2 (444 ms test)-------------------------------------------------------------------------------------------------------------------------------------------------
                  private List<int> wordCount;

                  public List<int> WordCount
                      {
                          get { return wordCount; }
                          set { wordCount = value; }
                      }
                  
                  public Words(int lineNumer)
                      {
                          wordCount = new List<int>();
                          wordCount.Add(lineNumer);
                      }

 //-------------------------------- The method generates information about the word-------------------------------------------
                  public string WordInfo(int pageSize)
                  {

                      string wordInfo =String.Format("\r\n  {0} total = {1} ", WorrdsValue.PadRight(18, '.'), WordCount.Count);
       
                      int  indexPage;
                      int tempIndexPage=0;
                      int tempWord=0;
                      int indexLine = 0;
                      foreach (int  line in WordCount )
                           {
                                  if (line == tempWord)
                                      {continue;}
                                   indexLine = line % pageSize;

                                   tempWord = line;
                                   indexPage=tempIndexPage;
                                   tempIndexPage = line / pageSize;

                                   if (indexLine > 0)
                                       {
                                           tempIndexPage++;
                                       }
                       
                                   if (indexPage!=tempIndexPage)
                                       {
                                           wordInfo = String.Concat(wordInfo,String.Format("\r\n    Page  {0} : ", tempIndexPage));
                                       }


                                   if (indexLine != 0)
                                       {

                                           wordInfo = String.Concat(wordInfo, String.Format("  {0}", indexLine));

                                       }
                                   else
                                       {
                                          wordInfo = String.Concat(wordInfo,String.Format( "  {0}",pageSize));
                                       }

                          }

                      return wordInfo;

                  }


     /* ver 1 (958 ms test)
                  byte[] wordCount;

                  public int WordCount { get { return wordCount.Length; } }

                  public Words(int size)
                      {
                          wordCount = new byte[size];
                      }

                  public int Total { get; set; }

                  public byte this[int indexWordCount] 
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

                                     // wordCount[0]++; // zero point contains information about the number of words in the text 

                                  }
                                        
                              }
        
                      }

                  //-------------------------------- The method generates information about the word-------------------------------------------
                  public string WordInfo(int pageSize, int textSize)
              {
            
                string wordInfo= string.Empty;

                wordInfo = String.Format("  {0} total = {1} \n\r", WorrdsValue.PadRight(18, '.'), Total);
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
          */
  }
}
