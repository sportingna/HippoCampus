using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HippoCampus.Models;

namespace HippoCampus.Controllers
{
    [Authorize(Roles = "Administrator, Student Worker")]
    public class ListModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ListModels
        public ActionResult Index()
        {
            return View(db.ListItem.ToList());
        }

        // GET: ListModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListItemModel listModel = db.ListItem.Find(id);
            if (listModel == null)
            {
                return HttpNotFound();
            }
            return View(listModel);
        }

        // GET: ListModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ListId,ListName,ListLevel,ListDec")] ListItemModel listModel)
        {
            if (ModelState.IsValid)
            {
                if (listModel.ListLevel == "0")
                {
                    listModel.ListLevel = "On Campus";
                }
                else if (listModel.ListLevel == "1")
                {
                    listModel.ListLevel = "Off Campus";
                }
                else if(listModel.ListLevel == "Recommended/Optional")
                {
                    listModel.ListLevel = "Recommended/Optional";
                }

                db.ListItem.Add(listModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listModel);
        }

        // GET: ListModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListItemModel listModel = db.ListItem.Find(id);
            if (listModel == null)
            {
                return HttpNotFound();
            }
            return View(listModel);
        }

        // POST: ListModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ListId,ListName,ListLevel,ListDec")] ListItemModel listModel)
        {
            if (ModelState.IsValid)
            {
                if (listModel.ListLevel == "0")
                {
                    listModel.ListLevel = "High";
                }
                else if (listModel.ListLevel == "1")
                {
                    listModel.ListLevel = "Mid";
                }
                else
                {
                    listModel.ListLevel = "Low";
                }

                db.Entry(listModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listModel);
        }

        // GET: ListModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListItemModel listModel = db.ListItem.Find(id);
            if (listModel == null)
            {
                return HttpNotFound();
            }
            return View(listModel);
        }

        // POST: ListModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListItemModel listModel = db.ListItem.Find(id);
            db.ListItem.Remove(listModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
