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


      //  public Task ProcessFile(Object obj)
    //    {
     //       var task = new Task();
     //         task.Start();
     //         return task;
     //  }
        
        
       public void  FileProces( Object obj)
        {
            FileSystemEventArgs args = (obj as FileSystemEventArgs);
            HandlerFile handlerFile = new HandlerFile(BufferOrders, FilesInfo, args);
            FileInfo fileinfo = new FileInfo(args.FullPath);
            string creationFileName = handlerFile.GetSaveFileFullPath;
            if (File.Exists(creationFileName) == true)
            {
                Thread.Sleep(10);
                fileinfo.Delete();
                return;
            }
            fileinfo.CopyTo(creationFileName);
           List<string> contentFIle=handlerFile.FileReader.GetContent(creationFileName);
           string managerName= handlerFile.ManagerName;
           handlerFile.AddToQueue(contentFIle, managerName);
           File.AppendAllText(creationFileName, "\r\n  processed");
           fileinfo.Delete();
        }

       public void AddContentToBd(ItemOrder order) 
        {   





        }
        
        private ItemOrderModels CreationModel (ItemOrder _order)
       {
           DAL.Customer customer = new DAL.Customer();
           DAL.Manager manager = new DAL.Manager();
           DAL.Product product = new DAL.Product();
           DAL.Order order = new DAL.Order();
           customer.Name = _order.Customer;
           manager.Name = _order.Manager;
           product.Description = _order.Product;
           order.Customer = customer;
           order.Manager = manager;
           order.Product = product;
           order.OrderDate = _order.OrderDate;
           order.Sum = _order.Price;
           ItemOrderModels itemOrderModels = new ItemOrderModels(customer, manager, order, product);
           return itemOrderModels;
       }

       public void watcher_Created(object sender, FileSystemEventArgs e)
       {
            FileProces(e);
           foreach (var order in BufferOrders)
           {
               Console.WriteLine("mn {0};  cust {1}; product {2};data {3}; sum{4}", order.Manager, order.Customer, order.Product, order.OrderDate.ToShortDateString(), order.Price.ToString());
           }
        
       }
    }
}
