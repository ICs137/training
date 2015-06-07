using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Concordance2
{
    public class FileManager: IFileManager
    {
        private readonly Encoding _defaultEncoding=Encoding.GetEncoding(1251);
        private readonly string _defaultFilePath;
        private readonly string _defaultSaveFilePath;
        public string FileName { get; set; }

        public FileManager(string fileName)
        {
            _defaultFilePath = "../../" + fileName;
            _defaultSaveFilePath = "../../" + "Concordance_" + fileName;
        }

        public FileManager()
        {
        }

        public List<string> GetContent()
        {
            return GetContent(_defaultFilePath, _defaultEncoding);
        }
        public List<string> GetContent(string filePath)
        {
            return GetContent(filePath, _defaultEncoding);
        }
        public List<string> GetContent(string filePath, Encoding encoding) //read file and separate the text into lines
        {
            List<string> lines = new List<string>();
            try
            {
                using (StreamReader streamreader = new StreamReader(filePath, encoding))
                {
                    while (streamreader.Peek() >= 0)
                    {
                        lines.Add(streamreader.ReadLine().ToLower());
                    }
                }
            }
            catch (Exception except)
            {
                Console.WriteLine("The process failed: {0}", except.Message);
            }
            return lines;
        }

        public void SaveContent(ICollection<string> OutputContent)
        {

            SaveContent(OutputContent, _defaultSaveFilePath, _defaultEncoding);

        }
        public void SaveContent(ICollection<string> OutputContent, string filePath)
        {

            SaveContent(OutputContent, filePath, _defaultEncoding);

        }
        public void SaveContent(ICollection<string> OutputContent, string filePath, Encoding encoding) //Save  output report about text  in the file 
        {
            if (OutputContent.Count > 1)
            {
                try
                {
                    using (StreamWriter swriter = new StreamWriter(filePath, false, encoding))
                    {
                        foreach (var item in OutputContent)
                        {
                            swriter.WriteLine(item);
                        }

                    }

                    Console.WriteLine(String.Concat("file is  recorded", filePath));

                }
                catch (Exception except)
                {
                    Console.WriteLine(except.Message);
                }
            }


        }
                
      
        
    }
}
