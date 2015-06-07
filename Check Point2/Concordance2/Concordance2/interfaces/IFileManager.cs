using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concordance2
{
    public interface IFileManager
    {
        List<string> GetContent();
        List<string> GetContent(string filePath);
        List<string> GetContent(string filePath, Encoding encoding);
        void SaveContent(ICollection<string> OutputContent);
        void SaveContent(ICollection<string> OutputContent, string filePath);
        void SaveContent(ICollection<string> OutputContent, string filePath, Encoding encoding);
         
    }
}
