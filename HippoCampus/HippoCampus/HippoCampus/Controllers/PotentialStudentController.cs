using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HippoCampus.Models;
using System.Diagnostics;
using System.Data.Entity.Validation;

namespace HippoCampus.Controllers
{
    public class PotentialStudentController : Controller
    {
        private HippoCampusDBEntities db = new HippoCampusDBEntities();

        // GET: PotentialStudent
        public ActionResult Index()
        {
            return View(db.ftre_stdnt.ToList());
        }

        // GET: PotentialStudent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ftre_stdnt ftre_stdnt = db.ftre_stdnt.Find(id);
            if (ftre_stdnt == null)
            {
                return HttpNotFound();
            }
            return View(ftre_stdnt);
        }

        // GET: PotentialStudent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PotentialStudent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bearpass_Id,ftre_stdnt_first_name,ftre_stdnt_last_name,ftre_stdnt_email,ftre_stdnt_dob,ftre_stdnt_gender,ftre_stdnt_arr_date_time,ftre_stdnt_flight_num,ftre_stdnt_trans_req,ftre_stdnt_des_desc,ftre_stdnt_other_desc")] ftre_stdnt ftre_stdnt)
        {
            if (ModelState.IsValid)
            {
                db.ftre_stdnt.Add(ftre_stdnt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ftre_stdnt);
        }
        //changes 
        // GET: PotentialStudent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ftre_stdnt ftre_stdnt = db.ftre_stdnt.Find(id);
            if (ftre_stdnt == null)
            {
                return HttpNotFound();
            }
            return View(ftre_stdnt);
        }

        // POST: PotentialStudent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind
          (Include = "bearpass_Id,ftre_stdnt_first_name,ftre_stdnt_last_name,ftre_stdnt_email,ftre_stdnt_dob,ftre_stdnt_gender,ftre_stdnt_arr_date_time,ftre_stdnt_flight_num,ftre_stdnt_trans_req,ftre_stdnt_des_desc,ftre_stdnt_other_desc")
            ] ftre_stdnt ftre_stdnt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ftre_stdnt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ftre_stdnt);
        }

        // GET: PotentialStudent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ftre_stdnt ftre_stdnt = db.ftre_stdnt.Find(id);
            if (ftre_stdnt == null)
            {
                return HttpNotFound();
            }
            return View(ftre_stdnt);
        }

        // POST: PotentialStudent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ftre_stdnt ftre_stdnt = db.ftre_stdnt.Find(id);
            db.ftre_stdnt.Remove(ftre_stdnt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Activate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ftre_stdnt ftre_stdnt = db.ftre_stdnt.Find(id);
            if (ftre_stdnt == null)
            {
                return HttpNotFound();
            }
            return View(ftre_stdnt);
        }

        [HttpPost, ActionName("Activate")]
        [ValidateAntiForgeryToken]
        public ActionResult ActivateConfirmed(int id)
        {
            ftre_stdnt ftre_stdnt = db.ftre_stdnt.Find(id);
            intr_stdnt intr_stdnt = new intr_stdnt(ftre_stdnt.bearpass_Id, ftre_stdnt.ftre_stdnt_first_name, ftre_stdnt.ftre_stdnt_last_name, ftre_stdnt.ftre_stdnt_email, ftre_stdnt.ftre_stdnt_dob, ftre_stdnt.ftre_stdnt_gender, ftre_stdnt.ftre_stdnt_arr_date_time, ftre_stdnt.ftre_stdnt_flight_num, ftre_stdnt.ftre_stdnt_trans_req, ftre_stdnt.ftre_stdnt_des_desc, ftre_stdnt.ftre_stdnt_other_desc);

            db.intr_stdnt.Add(intr_stdnt);
            db.ftre_stdnt.Remove(ftre_stdnt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void CreatingInternationalStudent(ftre_stdnt ftre_stdnt)
        {
            

            try { db.SaveChanges(); }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            //intr_stdnt.bearpass_Id = ftre_stdnt.bearpass_Id;
            //intr_stdnt.intr_stdnt_first_name = ftre_stdnt.ftre_stdnt_first_name;
            //intr_stdnt.intr_stdnt_last_name = ftre_stdnt.ftre_stdnt_last_name;
            //intr_stdnt.intr_stdnt_email = ftre_stdnt.ftre_stdnt_email;
            //intr_stdnt.intr_stdnt_dob = ftre_stdnt.ftre_stdnt_dob;
            //intr_stdnt.intr_stdnt_gender = ftre_stdnt.ftre_stdnt_gender;
            //intr_stdnt.intr_stdnt_arr_date_time = ftre_stdnt.ftre_stdnt_arr_date_time;
            //intr_stdnt.intr_stdnt_flight_num = ftre_stdnt.ftre_stdnt_flight_num;
            //intr_stdnt.intr_stdnt_trans_req = ftre_stdnt.ftre_stdnt_trans_req;
            //intr_stdnt.intr_stdnt_des_desc = ftre_stdnt.ftre_stdnt_des_desc;
            //intr_stdnt.intr_stdnt_other_desc = ftre_stdnt.ftre_stdnt_other_desc;

            return;
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
