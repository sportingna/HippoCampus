using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HippoCampus.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using HippoCampus.Enum;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;

namespace HippoCampus.Controllers
{
    [Authorize(Roles = "Administrator, Student Worker")]
    public class FutureStudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FutureStudent
        public ActionResult Index()
        {
            return View(db.FutureStudentModels.OrderBy(x=>x.ftre_stdnt_arr_date).ToList());
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
        [AllowAnonymous]
        // GET: FutureStudent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FutureStudent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FutureStudentCreateView model)
        {
            if (ModelState.IsValid)
            {
                string gender = GenderChoice(model.ftre_stdnt_gender);
                string request = Results(model.ftre_stdnt_trans_req);
                var userid = new ApplicationUser();
                FutureStudentModel student = new FutureStudentModel(userid.Id, model.bearpass_Id, model.ftre_stdnt_first_name,
                    model.ftre_stdnt_last_name, model.ftre_stdnt_email, model.ftre_stdnt_dob, gender, model.ftre_stdnt_arr_date,
                    model.ftre_stdnt_arr_time, model.ftre_stdnt_flight_num, request,
                    model.ftre_stdnt_des_desc, model.ftre_stdnt_other_desc);
                
                db.FutureStudentModels.Add(student);
                db.SaveChanges();
                return RedirectToAction("CreateSuccessful");
            }

            return View(model);
        }

        private string GenderChoice(Gender input)
        {
            string result;
            if (input == Gender.Male)
            {
                result = "Male";
            }
            else if (input == Gender.Female)
            {
                result = "Female";
            }

            else
            {
                result = "NA";
            }
            return result;
            
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
        [AllowAnonymous]
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
        public async Task<ActionResult> ActivateConfirmed(string id)
        {
            string roleName = "International Student";
            string password = "Password123!";

            FutureStudentModel ftre_stdnt = db.FutureStudentModels.Find(id);
            var user = new ApplicationUser { UserName = ftre_stdnt.ftre_stdnt_email, Email = ftre_stdnt.ftre_stdnt_email };
            DateTime combo = ftre_stdnt.ftre_stdnt_arr_date.Add(ftre_stdnt.ftre_stdnt_arr_time.TimeOfDay);
            InternStudentModel intr_stdnt = new InternStudentModel(user.Id, ftre_stdnt.bearpass_Id, ftre_stdnt.ftre_stdnt_first_name, ftre_stdnt.ftre_stdnt_last_name, ftre_stdnt.ftre_stdnt_email, ftre_stdnt.ftre_stdnt_dob, ftre_stdnt.ftre_stdnt_gender, combo, ftre_stdnt.ftre_stdnt_flight_num, ftre_stdnt.ftre_stdnt_trans_req, ftre_stdnt.ftre_stdnt_des_desc, ftre_stdnt.ftre_stdnt_other_desc);
                       
            db.InternStudentModels.Add(intr_stdnt);
            db.FutureStudentModels.Remove(ftre_stdnt);
            db.Users.Add(user);
            db.SaveChanges();        
            
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            UserManager.AddToRole(user.Id, roleName);
            var result = await UserManager.AddPasswordAsync(user.Id, password);

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
