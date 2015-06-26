using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BL
{
    public class HandlerFile
    {
        private ConcurrentQueue<ItemOrder> bufferOrders;
        public ConcurrentQueue<ItemOrder> BufferOrders
        {
            get { return bufferOrders; }
            set { bufferOrders = value; }
        }

        private readonly FilesInfo _filesInfo;
        public FilesInfo FilesInfoItem
        {
            get { return _filesInfo; }
        }
        private readonly string _fileName;
        public string FileName
        {
            get { return _fileName; }
        }
        public string ManagerName
        {
            get
            {
                string name = "NoName";
                Match match = Regex.Match(FileName, @"^[a-zA-Z]+");
                if (match.Success)
                {
                    name = match.Value;
                }
                return name;
            }
        }
        public string GetSaveFileFullPath
        { 
          get
            {
                return FilesInfoItem.DefaultSaveFilePath+"timecreation"+ DateTime.Now.ToString(@" hh\.mm\.ss\_") +FileName  ;
            }
        
        }

        private Parser parser = new Parser();
        public Parser Parser
        {
            get { return parser; }
        }

        private FileReader fileReader = new FileReader();
        public FileReader FileReader
        {
            get { return fileReader; }
        }
        
        public HandlerFile(ConcurrentQueue<ItemOrder> bufferOrders, FilesInfo filesInfo,FileSystemEventArgs args)
            {
                this.BufferOrders=bufferOrders;
                this._filesInfo = filesInfo;
                this._fileName = args.Name;
            }

        public void AddToQueue( string line,string managerName)
            {
                ItemOrder tempOrder = Parser.GetOrder(line, managerName);
                if (tempOrder == null)
                {
                    return;
                }
                BufferOrders.Enqueue(Parser.GetOrder(line, managerName));
            }

        public void AddToQueue (List<string> listOrder,string managerName )
        {
           foreach ( string order in listOrder   )
           {
               AddToQueue(order, managerName);
           }

        }
          

    }
}
