using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concordance
{
  public  class Words

  {
        string wordsValue;
        public string WorrdsValue {get;set;}

        int[] wordCount;

        public int WordCount { get { return wordCount.Length; } }

        public Words(int size)
            {
                wordCount = new int[size];
            }




      public int this[int indexWordCount] 
        { 
            
                get
                    {
                      if (indexWordCount>0)
                        {
                            return wordCount[indexWordCount];
                        }
                             else return wordCount.Sum();

                    } 
            
                set 
                    {
                        if (indexWordCount > 0)
                        {
                            wordCount[indexWordCount] = value;
                        }
                        else
                            if (indexWordCount == 0)

                                wordCount[indexWordCount] = 0;
                
                    }
        
            } 



     
    }
}
