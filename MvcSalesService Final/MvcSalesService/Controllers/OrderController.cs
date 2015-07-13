using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DAL;
using DAL.classes;
using MvcSalesService.Models;

namespace MvcSalesService.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        public int pageSize = 50;
        private  readonly TransporterIntoDb _transporterIntoDb= new TransporterIntoDb();


        [HttpGet]
        public ActionResult Index(int page = 1)

        {
            int skip = (page - 1)*pageSize;
            int count;
            IEnumerable<Order> oredrlist = _transporterIntoDb.OrderRepository.GetSomeOrders(skip, pageSize,out count);
            
            OrderListViewModel model = new OrderListViewModel
            {
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = count
                },
                Orders = oredrlist
            };
               

                return View(model); 
         
        }
     
       
        public ActionResult Details(int id = 0)
        {
            Order order = _transporterIntoDb.OrderRepository.GetItem(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        //
        // GET: /Order/Create


        [HttpGet]
        public ActionResult Filters()
        {

            ViewBag.FilterManagerId = new SelectList(_transporterIntoDb.ManagerRepository.Items, "ManagerId", "Name");
            ViewBag.FilterProductId = new SelectList(_transporterIntoDb.ProductRepository.Items, "ProductId", "Description");
            ViewBag.FilterCustomerId = new SelectList(_transporterIntoDb.CustomerRepository.Items, "CustomerId", "Name");
            OrderListViewModel modelPage = new OrderListViewModel();
            return View(modelPage);
        }

        [HttpPost]
        public ActionResult Filters(OrderListViewModel modelPage)
        {
                Session["modelPage"] = modelPage;
           return RedirectToAction("FiltersView"); 
        }
      
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
               _transporterIntoDb.OrderRepository.Add(order);
               _transporterIntoDb.OrderRepository.SaveChanges();
               return RedirectToAction("Index");
           }
            
            ViewBag.ManagerId = new SelectList(_transporterIntoDb.ManagerRepository.Items, "ManagerId", "Name");
            ViewBag.ProductId = new SelectList(_transporterIntoDb.ProductRepository.Items, "ProductId", "Description");
            ViewBag.CustomerId = new SelectList(_transporterIntoDb.CustomerRepository.Items, "CustomerId", "Name");
 
            return View( );
        }
      

        public ActionResult Edit(int id)
        {
            Order order = _transporterIntoDb.OrderRepository.GetItem(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManagerId = new SelectList(_transporterIntoDb.ManagerRepository.Items, "ManagerId", "Name");
            ViewBag.ProductId = new SelectList(_transporterIntoDb.ProductRepository.Items, "ProductId", "Description");
            ViewBag.CustomerId = new SelectList(_transporterIntoDb.CustomerRepository.Items, "CustomerId", "Name");
            return View(order);
        }
     

        [HttpPost]
    
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Order order)
        {
            try
            {
                _transporterIntoDb.OrderRepository.Update(order);
                _transporterIntoDb.OrderRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ManagerId = new SelectList(_transporterIntoDb.ManagerRepository.Items, "ManagerId", "Name");
                ViewBag.ProductId = new SelectList(_transporterIntoDb.ProductRepository.Items, "ProductId", "Description");
                ViewBag.CustomerId = new SelectList(_transporterIntoDb.CustomerRepository.Items, "CustomerId", "Name");
                return View(order);
            }
        }

        //
        // GET: /Order/Delete/5

        [HttpGet]
       
        public ActionResult Delete(int id)
        {
            Order order = _transporterIntoDb.OrderRepository.GetItem(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        //
        // POST: /Order/Delete/5

        [HttpPost]
      
        public ActionResult Delete(Order order,int id)
        {
            try
            {
                _transporterIntoDb.OrderRepository.Remove(id);
                _transporterIntoDb.OrderRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                Order tempOrderorder = _transporterIntoDb.OrderRepository.GetItem(id);
                return View(tempOrderorder);
            }
        }


        public ActionResult FiltersView(int page = 1)
        {
            if (Session["modelPage"] == null)
            {
                return RedirectToAction("Index");
            }
            OrderListViewModel modelPage = Session["modelPage"] as OrderListViewModel;
            if (modelPage != null)
            {
                int skip = (page - 1)*pageSize;
                int count;
                DAL.classes.IFilters filters= modelPage;
                modelPage.Orders = _transporterIntoDb.OrderRepository.GetSomeFilterOrders(skip, pageSize,
                    filters, out count);
                modelPage.PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = count
                };
                return View(modelPage);


            }
            return RedirectToAction("Index");
        }

    }
}
