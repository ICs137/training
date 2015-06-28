using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

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
        public string DefaultFilePath
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
            _defaultFilePath = @"E:\LIFE\EPAM\training\Check_Point4\PackerSalesReports\reports";           //  "../../../reports";
            // _defaultFilePath = System.Configuration.ConfigurationManager.AppSettings["Path"];  
            _defaultSaveFilePath = @"E:\LIFE\EPAM\training\Check_Point4\PackerSalesReports\Processed Reports\";   //"../../../Processed Reports/";
            // _defaultSaveFilePath = System.Configuration.ConfigurationManager.AppSettings["PathSave"];    does not find System.Configuration.ConfigurationManager ((
            
        }
              
    }
}
