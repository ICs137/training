using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BL
{
    public class FileReader
    {
        private readonly Encoding _defaultEncoding = Encoding.GetEncoding(1251);
        private readonly string _defaultFilePath;
        private readonly string _defaultSaveFilePath;
        private readonly string _fileName;
        public string FileName
        {
            get { return _fileName; }
        } 
        public FileReader( FileSystemEventArgs args, string savePath)
        {
            _fileName = args.Name;
            _defaultFilePath = args.FullPath;
            _defaultSaveFilePath = savePath + args.Name;
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

       



    }
}
