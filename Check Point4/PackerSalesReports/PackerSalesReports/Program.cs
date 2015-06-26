using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PackerSalesReports
{
    class Program
    {
        static void Main(string[] args)
        {

            BL.DataCollector dataCollector = new BL.DataCollector();
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = dataCollector.FilesInfo.DefaultFilePath;
            watcher.Filter = "*.csv";
            watcher.Created += new FileSystemEventHandler(dataCollector.watcher_Created);
            watcher.IncludeSubdirectories = false;
            watcher.EnableRaisingEvents = true;
            
            Console.ReadKey();

        }
    }
}
