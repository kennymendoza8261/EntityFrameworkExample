using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkExample.Models;
using EntityFrameworkExample.Services;

namespace DatabaseActivities.Controllers
{
    public class EmployeesController : Controller
    {
        private BarrelService service = new BarrelService();

        public ActionResult Index()
        {
            return View(service.GetAllBarrels());
        }


        public ActionResult Create()
        {
            return View();
        }

         //Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Barrel barrel)
        {
            if (ModelState.IsValid)
            {
                service.AddBarrel(barrel);
                return RedirectToAction("Index");
            }

            return View(barrel);
        }

        //Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barrel barrel = service.GetBarrelById((int)id);
            if (barrel == null)
            {
                return HttpNotFound();
            }
            return View(barrel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Barrel barrel = service.GetBarrelById(id);
            service.Delete(barrel);
            return RedirectToAction("Index");
        }

        //Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barrel barrel = service.GetBarrelById((int)id);
            if (barrel == null)
            {
                return HttpNotFound();
            }
            return View(barrel);
        }
    }
}
