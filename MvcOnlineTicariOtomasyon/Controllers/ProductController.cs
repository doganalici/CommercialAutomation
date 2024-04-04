using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context c = new Context();
        public ActionResult Index()
        {
            var urunler = c.Products.Where(x => x.Status == true).ToList();
            return View(urunler);

        }

        [HttpGet]
        public ActionResult ProductAdd()
        {
            List<SelectListItem> list = (from x in c.Categories.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.Name,
                                             Value = x.Id.ToString()
                                         }).ToList();
            ViewBag.lst1 = list;
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(Product pr)
        {
            c.Products.Add(pr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProductDelete(int id)
        {
            var prd = c.Products.Find(id);
            prd.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProductGet(int id)
        {
            List<SelectListItem> list = (from x in c.Categories.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.Name,
                                             Value = x.Id.ToString()
                                         }).ToList();
            ViewBag.lst1 = list;
            var product = c.Products.Find(id);
            return View("ProductGet", product);
        }

        public ActionResult ProductUpdate(Product prd)
        {
            var prdt = c.Products.Find(prd.Id);
            prdt.Name = prd.Name;
            prdt.Brand = prd.Brand;
            prdt.Stock = prd.Stock;
            prdt.BuyingPrice = prd.BuyingPrice;
            prdt.SellingPrice = prd.SellingPrice;
            prdt.Status = prd.Status;
            prdt.Image= prd.Image;
            prdt.CategoryId = prd.CategoryId;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}