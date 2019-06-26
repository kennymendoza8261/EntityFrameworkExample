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
    public class BarrelController : Controller
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
        public ActionResult Create(Barrel barrelCreate)
        {
            if (ModelState.IsValid)
            {
                barrelCreate.DateCreated = DateTime.Now;
                service.AddBarrel(barrelCreate);
                return RedirectToAction("Index");
            }

            return View(barrelCreate);
        }

        //Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barrel barrelDelete = service.GetBarrelById((int)id);
            if (barrelDelete == null)
            {
                return HttpNotFound();
            }
            return View(barrelDelete);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Barrel barrelDelete = service.GetBarrelById(id);
            service.Delete(barrelDelete);
            return RedirectToAction("Index");
        }

        //Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barrel barrelDetails = service.GetBarrelById((int)id);
            if (barrelDetails == null)
            {
                return HttpNotFound();
            }
            return View(barrelDetails);
        }
    }
}
