using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BL
{
    public class DataCollector
    {
        private DAL.ManagerRepository managerRepository = new DAL.ManagerRepository();
        private DAL.OrderRepository orderRepository = new DAL.OrderRepository();
        private DAL.ProductRepository productRepository = new DAL.ProductRepository();
        private DAL.CustomerRepository customerRepository = new DAL.CustomerRepository();

        private ConcurrentQueue<ItemOrder> bufferOrders = new ConcurrentQueue<ItemOrder>();
        public ConcurrentQueue<ItemOrder> BufferOrders
        {
            get { return bufferOrders; }
            set { bufferOrders = value; }
        }
        
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
        private readonly FilesInfo _filesInfo;
        public FilesInfo FilesInfo
        {
            get { return _filesInfo; }
        } 


        public DataCollector()
            {
                _filesInfo = new FilesInfo();
            }
        public DataCollector( string FilePath)
            {
                _filesInfo = new FilesInfo(FilePath);
            }
        public DataCollector(string FilePath, string SaveFilePath)
        {
            _filesInfo = new FilesInfo(FilePath, SaveFilePath);
        }






      //  public Task ProcessFile()
      //  {
      //  var task = new Task();
      //     task.Start();
      //     return task;
      //  }
        
  
       

       public void watcher_Created(object sender, FileSystemEventArgs e)
        {
            
            FileInfo finf = new FileInfo("../../../reports/"+ e.Name);
            string creationFileName = this.DefaultSaveFilePath +"timecreation"+ DateTime.Now.ToString(@" hh\.mm\.ss\_") + e.Name;

          if ( File.Exists( creationFileName)==true)
          {
              Thread.Sleep(10);
              finf.Delete();
           
              return;
          }
            finf.CopyTo(creationFileName);
            finf.Delete();
            finf.Delete();
            finf.Delete();
            File.AppendAllText(creationFileName, "  processed");
            Console.WriteLine(e.FullPath + "   " + creationFileName);
        }  
      



    }
}
