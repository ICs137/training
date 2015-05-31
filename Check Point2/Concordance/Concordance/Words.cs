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


            private ICollection<int> wordCount;

            public ICollection<int> WordCount
            {
                get { return wordCount; }
                set { wordCount = value; }
            }

            
        
            public void SetWordCount( int value )
                    {

                        wordCount.Add(value);

                    }
            
            public Words(int lineNumer)
                {
                    wordCount = new List<int>();
                    wordCount.Add(lineNumer);

                }
           
//---------------------------------------------------------------------------------------------------------------------------------------------------
            public string WordInfo(int pageSize, int textSize)
            {

                string wordInfo = string.Empty;

                wordInfo = String.Format("\r\n  {0} total = {1} ", WorrdsValue.PadRight(18, '.'), WordCount.Count);
         
                int  indexPage;
                int tempIndexPage=0;
               

                foreach (int  line in WordCount.Distinct() )
                     {
                             indexPage=tempIndexPage;
                             tempIndexPage = line / pageSize;

                             if (line % pageSize > 0)
                                 {
                                     tempIndexPage++;
                                 }
                       
                             if (indexPage!=tempIndexPage)
                                 {
                                     wordInfo = String.Concat(wordInfo, String.Format("\r\n    Page  {0} : ", tempIndexPage));
                                 }


                             if (line % pageSize != 0)
                                 { 

                                    wordInfo = String.Concat(wordInfo, String.Format("  {0}", line% pageSize));

                                 }
                             else
                                 {
                                    wordInfo = String.Concat(wordInfo, String.Format("  {0}",pageSize));
                                 }

                    }

                return wordInfo;

            }



       /* ver 1
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

                                wordCount[0]++; // zero point contains information about the number of words in the text 

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
      */
    }
}
