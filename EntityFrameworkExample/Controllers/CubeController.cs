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
            public ActionResult Create(Cube cubeCreate)
            {
                if (ModelState.IsValid)
                {
                    cubeCreate.DateCreated = DateTime.Now;
                    service.AddCube(cubeCreate);
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
        }
}

