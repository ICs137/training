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

            BL.BufferOrders buffer = new BL.BufferOrders();
            BL.DataCollector dataCollector = new BL.DataCollector(buffer);
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path=dataCollector.DefaultFilePath;
            watcher.Filter = "*.csv";
            watcher.Created += new FileSystemEventHandler(dataCollector.watcher_Created);
            watcher.IncludeSubdirectories = false;
            watcher.EnableRaisingEvents = true;
            string sdate = DateTime.Now.ToString(@" hh\.mm\.ss\_");
            DateTime t;
            DateTime.TryParseExact(sdate, @" hh\.mm\.ss\_", null, DateTimeStyles.None, out t);
            Console.WriteLine(t.ToString());
            Console.ReadKey();

        }
    }
}
