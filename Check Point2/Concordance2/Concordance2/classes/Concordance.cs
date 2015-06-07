using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concordance2
{
    public class Concordance
    {
        public int PageSize { get; set; }  // number of lines per page
        private IDictionary<string, Words> wordsCountDict = new Dictionary<string, Words>();
        private List<string> outputContent = new List<string>();
        public List<string> OutputContent { get { return outputContent; } }

        public Concordance()
        {
            PageSize = 42;
        }
                 
        public void CreateConcordance(List<string> lines)  // create the dictionary that contains information about  words: where key=this word
        {
            Parser parser = new Parser();
            int lineNumber = 1;
            foreach (var line in lines)
            {
                string[] Words = parser.GetWords(line);

                foreach (var word in Words)
                {
                    if (!Char.IsLetter(word[0]))
                    { continue; }

                    if (!wordsCountDict.ContainsKey(word))
                    {

                        wordsCountDict.Add(word, new Words (lineNumber) { WorrdsValue = word });

                    }
                    else
                    {
                        wordsCountDict[word].WordCount.Add(lineNumber);
                    }
                }
                lineNumber++;
            }
        }

        public void GetOutputContent()  // create the list that contains output report about text.
        {
      
            foreach (var alphabeticalGroup in wordsCountDict.OrderBy(x => x.Key).GroupBy(x => x.Key[0]))
            {
                outputContent.Add(String.Format("\n       -={0}=-", alphabeticalGroup.Key.ToString().ToUpper()));

                foreach (var itemGroup in alphabeticalGroup)
                {
                    outputContent.Add(itemGroup.Value.WordInfo(PageSize));

                }
                
            }
                        
        }
       

    }
}
