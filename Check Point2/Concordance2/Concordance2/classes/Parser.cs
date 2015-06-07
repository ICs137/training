using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concordance2
{
    public class Parser
    {

        private readonly string[] punctuationSeparators = new string[] { " '", ",", ".", "!", "?", "\"", ":", ";", "(", ")", "—", "' ", " ", "^" };

        public string[] GetWords(string line) // split a string into words
        {
            string[] words = line.Split(punctuationSeparators, StringSplitOptions.RemoveEmptyEntries); 
            return words;
        }

    }
}
