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

namespace EntityFrameworkExample.Controllers
{
        public class CubeController : Controller
        {
            private CubeService service = new CubeService();

            public ActionResult Index()
            {
                return View(service.GetAllCubes());
            }


            public ActionResult Create()
            {
                return View();
            }

            //Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(CubeCount cubeCreate)
            {
                if (ModelState.IsValid)
                {
                Cube temp = new Cube();
                temp.SideLength = cubeCreate.SideLength;
                temp.Weight = cubeCreate.Weight;
                temp.ConstructionMaterial = cubeCreate.ConstructionMaterial;
                temp.Contents = cubeCreate.Contents;
                temp.CurrentLocation = cubeCreate.CurrentLocation;
                temp.DateCreated = DateTime.Now;

                for (int i = 0; i < cubeCreate.Amount; i++)
                {
                    service.AddCube(temp);
                }
                return RedirectToAction("Index");
            }

                return View(cubeCreate);
            }

            //Delete
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Cube cubeDelete= service.GetCubeById((int)id);
                if (cubeDelete == null)
                {
                    return HttpNotFound();
                }
                return View(cubeDelete);
            }

            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                Cube cubeDelete = service.GetCubeById(id);
                service.Delete(cubeDelete);
                return RedirectToAction("Index");
            }

            //Details
            public ActionResult Details(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Cube cubeDetails = service.GetCubeById((int)id);
                if (cubeDetails == null)
                {
                    return HttpNotFound();
                }
                return View(cubeDetails);
            }

            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Cube cubeEdit = service.GetCubeById((int)id);
                if (cubeEdit == null)
                {
                    return HttpNotFound();
                }
                return View(cubeEdit);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(Cube cubeEdit)
            {
                if (ModelState.IsValid)
                {
                    service.Edit(cubeEdit);
                    return RedirectToAction("Index");
                }
                return View(cubeEdit);
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
            for (var i = 0; i < TaskIds.Count(); i++)
            {
                var todo = service.GetCubeById(TaskIds[i]);
                //remove the record from the database
                service.Delete(todo);
            }

            //redirect to index view once record is deleted
            return RedirectToAction("Index");
        }
    }
    }


