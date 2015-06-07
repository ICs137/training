using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concordance2
{
    public class Words
    {
        public string WorrdsValue { get; set; }
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

        public string WordInfo(int pageSize)   //The method generates information about the word
        {
            string wordInfo = String.Format("\r\n  {0} total = {1} ", WorrdsValue.PadRight(18, '.'), WordCount.Count);

            int indexPage;
            int tempIndexPage = 0;
            int tempWord = 0;
            int indexLine = 0;
            foreach (int line in WordCount)
            {
                if (line == tempWord)
                { continue; }


                tempWord = line;
                indexLine = line % pageSize;



                indexPage = tempIndexPage;
                tempIndexPage = line / pageSize;

                if (indexLine > 0)
                {
                    tempIndexPage++;
                }

                if (indexPage != tempIndexPage)
                {
                    wordInfo = String.Concat(wordInfo, String.Format("\r\n    Page  {0} : ", tempIndexPage));
                }


                if (indexLine != 0)
                {

                    wordInfo = String.Concat(wordInfo, String.Format("  {0}", indexLine));

                }
                else
                {
                    wordInfo = String.Concat(wordInfo, String.Format("  {0}", pageSize));
                }

            }

            return wordInfo;

        }
    }
}
