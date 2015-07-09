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
        private int TaskCountReadFile { get; set; } // counter tasks for files processing;
        private int TaskCountWriteDB { get; set; } // counter tasks for writing the DB;
        private Object thisLock = new Object();
        private Object thisLock2 = new Object();
        private DAL.TransporterIntoDB transporterIntoDB = new DAL.TransporterIntoDB();
        public DAL.TransporterIntoDB TransporterIntoDB
        {
            get { return transporterIntoDB; }
            set { transporterIntoDB = value; }
        }
        private ConcurrentQueue<ItemOrder> bufferOrders = new ConcurrentQueue<ItemOrder>();
        public ConcurrentQueue<ItemOrder> BufferOrders
        {
            get { return bufferOrders; }
            set { bufferOrders = value; }
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
        public void FileProcess(FileSystemEventArgs args) // the main method of  file processing
        {
           lock (thisLock)
                {
                    TaskCountReadFile++;
                }
           HandlerFile handlerFile = new HandlerFile(BufferOrders, FilesInfo, args);
           FileInfo fileinfo = new FileInfo(args.FullPath);
           string creationFileName = handlerFile.GetSaveFileFullPath;
           string marker = "\r\n  processed "; //the result label file processing
           if (File.Exists(creationFileName) == true)
                {
                    Thread.Sleep(10);
                    fileinfo.Delete();
                    return;
                }
           fileinfo.CopyTo(creationFileName); 
           List<string> contentFIle=handlerFile.FileReader.GetContent(creationFileName);
           string managerName= handlerFile.ManagerName;
           handlerFile.AddContextToQueue(contentFIle, managerName, ref marker);
           lock (thisLock)
               {
                   TaskCountReadFile++;
               }
           File.AppendAllText(creationFileName, marker); //adding of the report about the results of file processing to the end of the file
           if (File.Exists(fileinfo.FullName) == true)
               {
                   fileinfo.Delete();
               }
                      
        }
        public void AddContentToDB() // the main method of recording in the DB
        {
            if (TaskCountWriteDB > 0)
                {
                    return;
                }
            lock (thisLock2)
                {
                    TaskCountWriteDB++;
                }
           ItemOrderModels itemOrderModel = null;
           ItemOrder itemOrder= null;
           while (BufferOrders.Count > 0 && TaskCountReadFile>0)
               {
                   for (int i=0; i<15; i++)
                   {
                      if(BufferOrders.Count==0)
                            {
                                break;
                            }
                     bool result= BufferOrders.TryDequeue(out itemOrder);
                     if(!result)
                            {
                                continue;
                            }
                     itemOrderModel = CreationModel(itemOrder);
                     AddModelToDB(itemOrderModel);
                   }
         
                   TransporterIntoDB.Context.SaveChanges();
                   }
           if (TaskCountReadFile > 0)
           {
               lock (thisLock2)
               {
                   TaskCountWriteDB--;
               }
               Task.Run(() => AddContentToDB());
           }

           lock (thisLock2)
               {
                   TaskCountWriteDB--;
               }
        } 
        private void AddModelToDB (ItemOrderModels itemOrderModels)
           {
               TransporterIntoDB.ManagerRepository.Update(itemOrderModels.Manager);
               TransporterIntoDB.ProductRepository.Update(itemOrderModels.Product);
               TransporterIntoDB.CustomerRepository.Update(itemOrderModels.Customer);
               TransporterIntoDB.OrderRepository.Add(itemOrderModels.Order);
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
               Task.Run(() => FileProcess(e));
               Task.Run(() => AddContentToDB());
           }
    }
}
