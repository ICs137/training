using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class FilesInfo
    {
        private readonly string _defaultSaveFilePath;
        public string DefaultSaveFilePath
        {
            get { return _defaultSaveFilePath; }
        }
        private readonly string _defaultFilePath;
        public string DefaultFilePath1
        {
            get { return _defaultFilePath; }
        }
        public FilesInfo (  string FilePath, string SaveFilePath)
        {
            FilePath = _defaultFilePath;
            SaveFilePath = _defaultSaveFilePath; 
        }
        public FilesInfo(string FilePath)
        {
            _defaultFilePath = FilePath;
            _defaultSaveFilePath = "../../../Processed Reports";
        }
        public FilesInfo()
        {
            _defaultFilePath = "../../../reports";
            _defaultSaveFilePath = "../../../Processed Reports/";
        }
        



    }
}
