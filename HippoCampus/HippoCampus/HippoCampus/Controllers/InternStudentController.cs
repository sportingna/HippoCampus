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
    public class InternStudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InternStudent
        public ActionResult Index()
        {
            return View(db.InternStudentModels.ToList());
        }

        // GET: InternStudent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InternStudentModel internStudentModel = db.InternStudentModels.Find(id);
            if (internStudentModel == null)
            {
                return HttpNotFound();
            }
            return View(internStudentModel);
        }

        // GET: InternStudent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InternStudent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bearpass_Id,intr_stdnt_first_name,intr_stdnt_last_name,intr_stdnt_email,intr_stdnt_dob,intr_stdnt_gender,intr_stdnt_arr_date_time,intr_stdnt_flight_num,intr_stdnt_trans_req,intr_stdnt_des_desc,intr_stdnt_other_desc")] InternStudentModel internStudentModel)
        {
            if (ModelState.IsValid)
            {
                db.InternStudentModels.Add(internStudentModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(internStudentModel);
        }

        // GET: InternStudent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InternStudentModel internStudentModel = db.InternStudentModels.Find(id);
            if (internStudentModel == null)
            {
                return HttpNotFound();
            }
            return View(internStudentModel);
        }

        // POST: InternStudent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bearpass_Id,intr_stdnt_first_name,intr_stdnt_last_name,intr_stdnt_email,intr_stdnt_dob,intr_stdnt_gender,intr_stdnt_arr_date_time,intr_stdnt_flight_num,intr_stdnt_trans_req,intr_stdnt_des_desc,intr_stdnt_other_desc")] InternStudentModel internStudentModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(internStudentModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(internStudentModel);
        }

        // GET: InternStudent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InternStudentModel internStudentModel = db.InternStudentModels.Find(id);
            if (internStudentModel == null)
            {
                return HttpNotFound();
            }
            return View(internStudentModel);
        }

        // POST: InternStudent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InternStudentModel internStudentModel = db.InternStudentModels.Find(id);
            db.InternStudentModels.Remove(internStudentModel);
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
