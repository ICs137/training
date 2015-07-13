using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using DAL.classes;
using Microsoft.Ajax.Utilities;
using MvcSalesService.Models;

namespace MvcSalesService.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        public int pageSize = 50;
        private  readonly DAL.classes.TransporterIntoDb _transporterIntoDb= new TransporterIntoDb();


        [HttpGet]
        public ActionResult Index(int page = 1)
        {
           
            IEnumerable<Order> oredrlist = _transporterIntoDb.OrderRepository.Items;
            IEnumerable<Order> enumerable = oredrlist as IList<Order> ?? oredrlist.ToList();
            OrderListViewModel model = new OrderListViewModel()
            {
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = enumerable.Count()
                },
                 Orders = enumerable.Skip((page - 1) * pageSize).Take(pageSize)
            };
               

                return View(model); 
         
        }
     
       

        

        public ActionResult Details(int id = 0)
        {
            DAL.Order order = _transporterIntoDb.OrderRepository.GetItem(id);
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
            DAL.Order order = _transporterIntoDb.OrderRepository.GetItem(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManagerId = new SelectList(_transporterIntoDb.ManagerRepository.Items, "ManagerId", "Name");
            ViewBag.ProductId = new SelectList(_transporterIntoDb.ProductRepository.Items, "ProductId", "Description");
            ViewBag.CustomerId = new SelectList(_transporterIntoDb.CustomerRepository.Items, "CustomerId", "Name");
            return View(order);
        }

        //
        // POST: /Order/Edit/5

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
            DAL.Order order = _transporterIntoDb.OrderRepository.GetItem(id);
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
                DAL.Order tempOrderorder = _transporterIntoDb.OrderRepository.GetItem(id);
                return View(tempOrderorder);
            }
        }


        public ActionResult FiltersView(int page = 1)
        {
            if (Session["modelPage"] == null)
            {
                return RedirectToAction("Index");
            }
            OrderListViewModel model;
            IEnumerable<Order> oredrlist = _transporterIntoDb.OrderRepository.Items;
            OrderListViewModel modelPage = Session["modelPage"] as OrderListViewModel;
            if (modelPage != null)
            {
                model = modelPage;

                if (model.FilterManagerId != 0)
                {

                    Manager firstOrDefault = _transporterIntoDb.ManagerRepository.Items.FirstOrDefault(
                        x => x.ManagerId == model.FilterManagerId);
                    if (firstOrDefault != null)
                    {
                        IEnumerable<Order> temList = oredrlist.Where(x => x.Manager.Name == firstOrDefault.Name);
                        oredrlist = temList;
                    }

                }

                if (model.FilterCustomerId != 0)
                {
                    Customer firstOrDefault = _transporterIntoDb.CustomerRepository.Items.FirstOrDefault(
                       x => x.CustomerId == model.FilterCustomerId);
                    if (firstOrDefault != null)
                    {
                        IEnumerable<Order> temList = oredrlist.Where(x => x.Customer.Name == firstOrDefault.Name);
                        oredrlist = temList;
                    }
                }

                if (model.FilterProductId != 0)
                {
                    Product firstOrDefault = _transporterIntoDb.ProductRepository.Items.FirstOrDefault(
                       x => x.ProductId == model.FilterProductId);
                    if (firstOrDefault != null)
                    {
                        IEnumerable<Order> temList = oredrlist.Where(x => x.Product.Description == firstOrDefault.Description);
                        oredrlist = temList;
                    }
                }

                model.PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = oredrlist.Count()
                };
                model.Orders = oredrlist.Skip((page - 1) * pageSize).Take(pageSize);

                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

    }
}
