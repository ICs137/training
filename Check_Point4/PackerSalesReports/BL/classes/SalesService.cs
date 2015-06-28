using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
  public  class SalesService
    {

        private BL.DataCollector dataCollector;
        private FileSystemWatcher watcher;
        public SalesService()
             {
                  dataCollector = new BL.DataCollector();
                  watcher = new FileSystemWatcher();
                  Initialization();
             }
        private void Initialization()
             {
                 watcher.Path = dataCollector.FilesInfo.DefaultFilePath;
                 watcher.Filter = "*.csv";
                 watcher.Created += new FileSystemEventHandler(dataCollector.watcher_Created);
                 watcher.IncludeSubdirectories = false;
                 watcher.EnableRaisingEvents = true;
             }

    }
}
