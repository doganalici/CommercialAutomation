using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        Context c = new Context();
        public ActionResult Index()
        {
            var departmanlar = c.Departments.Where(x => x.Status == true).ToList();
            return View(departmanlar);
        }

        [HttpGet]
        public ActionResult DepartmentAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmentAdd(Department dp)
        {
            c.Departments.Add(dp);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmentDelete(int id)
        {
            var dpr = c.Departments.Find(id);
            dpr.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmentGet(int id)
        {
            var department = c.Departments.Find(id);
            return View("DepartmentGet", department);
        }

        public ActionResult DepartmentUpdate(Department dp)
        {
            var dprt = c.Departments.Find(dp.Id);
            dprt.Name = dp.Name;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmentDetail(int id)
        {
            var personeller = c.Employees.Where(x => x.DepartmentId == id).ToList();
            var dpt = c.Departments.Where(x => x.Id == id).Select(y => y.Name).FirstOrDefault();
            ViewBag.d = dpt;
            return View(personeller);
        }
        public ActionResult DepartmentPersonnelSales(int id)
        {
            var personel = c.SalesActivitiess.Where(x => x.EmployeeId == id).ToList();
            var dps = c.Employees.Where(x => x.Id == id).Select(y => y.FirstName+" "+y.LastName).FirstOrDefault();
            ViewBag.dp = dps;
            return View(personel);
        }
    }
}