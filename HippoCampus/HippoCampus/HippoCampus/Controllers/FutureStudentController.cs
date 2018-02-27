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
    public class FutureStudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FutureStudent
        public ActionResult Index()
        {
            return View(db.FutureStudentModels.ToList());
        }

        // GET: FutureStudent/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FutureStudentModel futureStudentModel = db.FutureStudentModels.Find(id);
            if (futureStudentModel == null)
            {
                return HttpNotFound();
            }
            return View(futureStudentModel);
        }

        // GET: FutureStudent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FutureStudent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FutureStudentModel model)
        {
            if (ModelState.IsValid)
            {
                var userid = new ApplicationUser();
                FutureStudentModel student = new FutureStudentModel(userid.Id, model.bearpass_Id, model.ftre_stdnt_first_name,
                    model.ftre_stdnt_last_name, model.ftre_stdnt_email, model.ftre_stdnt_dob, model.ftre_stdnt_gender, model.ftre_stdnt_arr_date,
                    model.ftre_stdnt_arr_time, model.ftre_stdnt_flight_num, model.ftre_stdnt_trans_req,
                    model.ftre_stdnt_des_desc, model.ftre_stdnt_other_desc);
                db.FutureStudentModels.Add(student);
                db.SaveChanges();
                return RedirectToAction("CreateSuccessful");
            }

            return View(model);
        }

        public ActionResult CreateSuccessful()
        {
            return View();
        }

        // GET: FutureStudent/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FutureStudentModel futureStudentModel = db.FutureStudentModels.Find(id);
            if (futureStudentModel == null)
            {
                return HttpNotFound();
            }
            return View(futureStudentModel);
        }

        // POST: FutureStudent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bearpass_Id,ftre_stdnt_first_name,ftre_stdnt_last_name,ftre_stdnt_email,ftre_stdnt_dob,ftre_stdnt_gender,ftre_stdnt_arr_date_time,ftre_stdnt_flight_num,ftre_stdnt_trans_req,ftre_stdnt_des_desc,ftre_stdnt_other_desc")] FutureStudentModel futureStudentModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(futureStudentModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(futureStudentModel);
        }

        // GET: FutureStudent/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FutureStudentModel futureStudentModel = db.FutureStudentModels.Find(id);
            if (futureStudentModel == null)
            {
                return HttpNotFound();
            }
            return View(futureStudentModel);
        }

        // POST: FutureStudent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            FutureStudentModel futureStudentModel = db.FutureStudentModels.Find(id);
            db.FutureStudentModels.Remove(futureStudentModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Activate(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FutureStudentModel futureStudentModel = db.FutureStudentModels.Find(id);
            if (futureStudentModel == null)
            {
                return HttpNotFound();
            }
            return View(futureStudentModel);
        }

        [HttpPost, ActionName("Activate")]
        [ValidateAntiForgeryToken]
        public ActionResult ActivateConfirmed(string id)
        {
            FutureStudentModel ftre_stdnt = db.FutureStudentModels.Find(id);
            var userId = new ApplicationUser();
            DateTime combo = ftre_stdnt.ftre_stdnt_arr_date.Add(ftre_stdnt.ftre_stdnt_arr_time.TimeOfDay);
            InternStudentModel intr_stdnt = new InternStudentModel(userId.Id, ftre_stdnt.bearpass_Id, ftre_stdnt.ftre_stdnt_first_name, ftre_stdnt.ftre_stdnt_last_name, ftre_stdnt.ftre_stdnt_email, ftre_stdnt.ftre_stdnt_dob, ftre_stdnt.ftre_stdnt_gender, combo, ftre_stdnt.ftre_stdnt_flight_num, ftre_stdnt.ftre_stdnt_trans_req, ftre_stdnt.ftre_stdnt_des_desc, ftre_stdnt.ftre_stdnt_other_desc);

            db.InternStudentModels.Add(intr_stdnt);
            db.FutureStudentModels.Remove(ftre_stdnt);
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
