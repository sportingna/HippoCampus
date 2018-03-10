using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HippoCampus.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Data.Entity.Infrastructure;
using HippoCampus.Enum;

namespace HippoCampus.Controllers
{
    [Authorize(Roles = "Administrator, Student Worker")]
    public class StudentWorkerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentWorker
        public ActionResult Index()
        {
            return View(db.StudentWorker.ToList());
        }

        

        // GET: StudentWorker/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentWorkerModel studentWorkerModel = db.StudentWorker.Find(id);
            ApplicationUser user = db.Users.Find(id);
            
            RegisterStudentWorkerViewModel registerWorker = new RegisterStudentWorkerViewModel
                (user.Email, user.PhoneNumber, studentWorkerModel.wrkr_stdnt_first_name, 
                studentWorkerModel.wrkr_stdnt_last_name, studentWorkerModel.wrkr_stdnt_transport, 
                studentWorkerModel.wrkr_stdnt_availability);

            if (studentWorkerModel == null)
            {
                return HttpNotFound();
            }
            return View(registerWorker);
        }

        
        

        // GET: StudentWorker/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentWorkerModel studentWorkerModel = db.StudentWorker.Find(id);
            if (studentWorkerModel == null)
            {
                return HttpNotFound();
            }
            return View(studentWorkerModel);
        }

        // POST: StudentWorker/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RegisterStudentWorkerCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string transport = Results(model.wrkr_stdnt_transport);
                string avail = Results(model.wrkr_stdnt_availability);
                StudentWorkerModel studentWorkerModel = db.StudentWorker.Find(model.wrkr_stdnt_id);
                studentWorkerModel.wrkr_stdnt_first_name = model.wrkr_stdnt_first_name;
                studentWorkerModel.wrkr_stdnt_last_name = model.wrkr_stdnt_last_name;
                studentWorkerModel.wrkr_stdnt_transport = transport;
                studentWorkerModel.wrkr_stdnt_availability = avail;
                db.Entry(studentWorkerModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        private string Results(YesOrNo input)
        {
            string result;
            if (input == YesOrNo.Yes)
            {
                result = "Yes";
            }
            else
            {
                result = "No";
            }
            return result;
        }

        // GET: StudentWorker/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentWorkerModel studentWorkerModel = db.StudentWorker.Find(id);
            if (studentWorkerModel == null)
            {
                return HttpNotFound();
            }
            return View(studentWorkerModel);
        }

        // POST: StudentWorker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser user = db.Users.Find(id);
            db.Users.Remove(user);
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
