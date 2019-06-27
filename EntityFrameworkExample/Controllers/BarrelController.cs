using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkExample.Data.Context;
using EntityFrameworkExample.Models;
using EntityFrameworkExample.Services;

namespace EntityFrameworkExample.Controllers
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
        public ActionResult Create(BarrelCount barrelCreate)
        {
            if (ModelState.IsValid)
            {
                Barrel temp = new Barrel();
                temp.Radius = barrelCreate.Radius;
                temp.Height = barrelCreate.Height;
                temp.Weight = barrelCreate.Weight;
                temp.ConstructionMaterial = barrelCreate.ConstructionMaterial;
                temp.Contents = barrelCreate.Contents;
                temp.CurrentLocation = barrelCreate.CurrentLocation;
                temp.DateCreated = DateTime.Now;

                for(int i = 0; i<barrelCreate.Amount; i++)
                {
                    service.AddBarrel(temp);
                }
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

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barrel barrelEdit = service.GetBarrelById((int)id);
            if (barrelEdit == null)
            {
                return HttpNotFound();
            }
            return View(barrelEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Barrel barrelEdit)
        {
            if (ModelState.IsValid)
            {
                service.Edit(barrelEdit);
                return RedirectToAction("Index");
            }
            return View(barrelEdit);
        }

        public ActionResult DeleteSelected(string[] ids)
        {
            if (ids == null || ids.Length == 0)
            {
                //throw error
                ModelState.AddModelError("", "No item selected to delete");
                return View();
            }
            //bind the task collection into list
            List<int> TaskIds = ids.Select(x => Int32.Parse(x)).ToList();
            for (var i = 0; i<TaskIds.Count(); i++)
            {
                var todo = service.GetBarrelById(TaskIds[i]);
                //remove the record from the database
                service.Delete(todo);
            }
            
            //redirect to index view once record is deleted
            return RedirectToAction("Index");
        }

    }
}
