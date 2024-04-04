using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler=c.Categories.ToList(); ;
            return View(degerler);
        }
        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(Category ct)
        {
            c.Categories.Add(ct);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CategoryDelete(int id)
        {
            var ctg = c.Categories.Find(id);
            c.Categories.Remove(ctg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CategoryGet(int id)
        {
            var category = c.Categories.Find(id);
            return View("CategoryGet", category);
        }

        public ActionResult CategoryUpdate(Category ct)
        {
            var ctgr=c.Categories.Find(ct.Id);
            ctgr.Name = ct.Name;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}