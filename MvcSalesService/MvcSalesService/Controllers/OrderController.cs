using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.classes;

namespace MvcSalesService.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        
        private  readonly DAL.classes.TransporterIntoDb _transporterIntoDb= new TransporterIntoDb();
        private readonly  DAL.OrderRepository _orderRepository= new OrderRepository();
       
  
        public ActionResult Index(int id=0)
        {
        
            var list = _orderRepository.Items.Skip(id).Take(3); ;
            ViewBag.count = 3;
            return View(list );
            id += 3;
        }

        [HttpPost]
        public ActionResult Index()
        {
           // ViewBag.count = id + 3;
           // var list = _orderRepository.Items.Skip(id).Take(3);

           return View();
        }



        public ActionResult Details(int id = 0)
        {
            DAL.Order order = _orderRepository.GetItem(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        //
        // GET: /Order/Create

         [HttpGet]
        public ActionResult Create()

        {

             ViewBag.ManagerId = new SelectList(_transporterIntoDb.ManagerRepository.Items, "ManagerId", "Name");
             ViewBag.ProductId = new SelectList(_transporterIntoDb.ProductRepository.Items, "ProductId","Description");
             ViewBag.CustomerId = new SelectList(_transporterIntoDb.CustomerRepository.Items, "CustomerId","Name");
             return View();
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
           {
                _orderRepository.Add(order);
                _orderRepository.SaveChanges();
                return RedirectToAction("Index");
           }
            ProductRepository productRepository = new ProductRepository();
            CustomerRepository customerRepository = new CustomerRepository();
            ManagerRepository managerRepository = new ManagerRepository();

            ViewBag.ManagerId = new SelectList(_transporterIntoDb.ManagerRepository.Items, "ManagerId", "Name");
            ViewBag.ProductId = new SelectList(_transporterIntoDb.ProductRepository.Items, "ProductId", "Description");
            ViewBag.CustomerId = new SelectList(_transporterIntoDb.CustomerRepository.Items, "CustomerId", "Name");
 


            return View( );
        }
        //
        // POST: /Order/Create

       
        //
        // GET: /Order/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Order/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Order/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Order/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
