using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        Context c = new Context();
        public ActionResult Index()
        {
            var musteriler = c.Customers.Where(x => x.Status == true).ToList();
            return View(musteriler);
        }

        [HttpGet]
        public ActionResult CustomerAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomerAdd(Customer cs)
        {
            if (!ModelState.IsValid)
            {
                return View("CustomerAdd");
            }
            cs.Status = true;
            c.Customers.Add(cs);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CustomerDelete(int id)
        {
            var cst = c.Customers.Find(id);
            cst.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CustomerGet(int id)
        {
            var customer= c.Customers.Find(id);
            return View("CustomerGet", customer);
        }

        public ActionResult CustomerUpdate(Customer cs)
        {
            if (!ModelState.IsValid)
            {
                return View("CustomerGet");
            }
            var cstm=c.Customers.Find(cs.Id);
            cstm.FirstName = cs.FirstName;
            cstm.LastName = cs.LastName;
            cstm.City = cs.City;
            cstm.Mail = cs.Mail;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult CustomerSales(int id)
        {
            var musteri = c.SalesActivitiess.Where(x => x.CustomerId == id).ToList();
            var cs=c.Customers.Where(x => x.Id == id).Select(y => y.FirstName + " " + y.LastName).FirstOrDefault();
            ViewBag.customer = cs;
            return View(musteri);
        }
    }
}