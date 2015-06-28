using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class TransporterIntoDB
    {
        private readonly Model.SaleContainer context;
        public Model.SaleContainer Context
        {
            get { return context; }
        }
        private readonly ManagerRepository managerRepository;
        public ManagerRepository ManagerRepository
            {
                get { return managerRepository; }
            }
        private readonly OrderRepository orderRepository;
        public OrderRepository OrderRepository
            {
                get { return orderRepository; }
            }
        private readonly ProductRepository productRepository;
        public ProductRepository ProductRepository
            {
                get { return productRepository; }
            }
        private readonly CustomerRepository customerRepository;
        public CustomerRepository CustomerRepository
            {
                get { return customerRepository; }
            } 

       public TransporterIntoDB()
        {

           this.context = new Model.SaleContainer();
           this.managerRepository = new DAL.ManagerRepository(context);
           this.orderRepository = new DAL.OrderRepository(context);
           this.productRepository = new DAL.ProductRepository(context);
           this.customerRepository = new DAL.CustomerRepository(context);
           
        }



    }
}
