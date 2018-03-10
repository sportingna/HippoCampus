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
    public class InternStudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InternStudent
        public ActionResult Index()
        {
            return View(db.InternStudentModels.OrderBy(x=>x.intr_stdnt_arr_date_time).ToList());
        }

        // GET: InternStudent/Details/5
        public ActionResult Details(string id)
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
        public ActionResult Edit(string id)
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
        public ActionResult Delete(string id)
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
        public ActionResult DeleteConfirmed(string id)
        {
            InternStudentModel internStudentModel = db.InternStudentModels.Find(id);
            db.InternStudentModels.Remove(internStudentModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult StudentListCreateView(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InternStudentModel internStudentModel = db.InternStudentModels.Find(id);

            StudentListView studentList = SeperatedListByPriority(id);

            if (internStudentModel == null)
            {
                return HttpNotFound();
            }


            return View(studentList);
        }

        public ActionResult CompletedListItem(string studId, int listId)
        {
            string completed = "Completed";
            var item = new InternList(studId, listId, completed);
            db.InternLists.Add(item);
            db.SaveChanges();

            if (studId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InternStudentModel internStudentModel = db.InternStudentModels.Find(studId);

            StudentListView studentList = SeperatedListByPriority(studId);

            if (internStudentModel == null)
            {
                return HttpNotFound();
            }


            return RedirectToAction(studId, "InternStudent/StudentListCreateView");
        }

        public ActionResult RemoveListItem(string studId, int listId)
        {
            
           var removeItem = db.InternLists.Where(x => x.ListId.Equals(listId) && x.UserId.Contains(studId)).ToList();
            foreach(var item in removeItem)
            {
                db.InternLists.Remove(item);
            }
            
            db.SaveChanges();

            if (studId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InternStudentModel internStudentModel = db.InternStudentModels.Find(studId);

            StudentListView studentList = SeperatedListByPriority(studId);

            if (internStudentModel == null)
            {
                return HttpNotFound();
            }


            return RedirectToAction(studId, "InternStudent/StudentListCreateView");
        }

        private StudentListView SeperatedListByPriority(string id)
        {
            var allItem = db.InternLists.Where(x => x.UserId.Contains(id));
            var allPriOneItem = db.ListItem.Where(x => x.ListLevel.Contains("On Campus"));
            var allPriTwoItem = db.ListItem.Where(x => x.ListLevel.Contains("Off Campus"));
            var allPriThreeItem = db.ListItem.Where(x => x.ListLevel.Contains("2"));

            InternStudentModel internStudent = db.InternStudentModels.Find(id);
            string fullname = internStudent.intr_stdnt_first_name + " " + internStudent.intr_stdnt_last_name;
            var priOne = new List<ListModel>();
            var priTwo = new List<ListModel>();
            var priThree = new List<ListModel>();
            foreach (var item in allPriOneItem)
            {
                var maybe = db.InternLists.Where(x=>x.ListId.Equals(item.ListId)&& x.UserId.Contains(id)).ToList();
                
                if (maybe.Count==0)
                { 
                    string completed = "No";
                    ListModel liMod = new ListModel(item.ListId, item.ListName, item.ListLevel, item.ListDec, completed);
                    priOne.Add(liMod);                    
                }
                else
                {
                    string completed = "Completed";
                    ListModel li = new ListModel(item.ListId, item.ListName, item.ListLevel, item.ListDec, completed);
                    priOne.Add(li);
                }

            }
                //if (allItem.Where(x => x.ListId.Equals(item.ListId)) != null)
                //{
                //    ListModel liMod = new ListModel(item.ListId, item.ListName, item.ListLevel, item.ListDec);
                //    priOne.Add(liMod);

                //}
            
            foreach (var item in allPriTwoItem)
            {
                var maybe = db.InternLists.Where(x => x.ListId.Equals(item.ListId) && x.UserId.Contains(id)).ToList();

                if (maybe.Count == 0)
                {
                    string completed = "No";
                    ListModel liMod = new ListModel(item.ListId, item.ListName, item.ListLevel, item.ListDec, completed);
                    priTwo.Add(liMod);
                }
                else
                {
                    string completed = "Completed";
                    ListModel li = new ListModel(item.ListId, item.ListName, item.ListLevel, item.ListDec, completed);
                    priTwo.Add(li);
                }



            }
            foreach (var item in allPriThreeItem)
            {
                var maybe = db.InternLists.Where(x => x.ListId.Equals(item.ListId) && x.UserId.Contains(id)).ToList();

                if (maybe.Count == 0)
                {
                    string completed = "No";
                    ListModel liMod = new ListModel(item.ListId, item.ListName, item.ListLevel, item.ListDec, completed);
                    priThree.Add(liMod);
                }
                else
                {
                    string completed = "Completed";
                    ListModel li = new ListModel(item.ListId, item.ListName, item.ListLevel, item.ListDec, completed);
                    priThree.Add(li);
                }
            }

            StudentListView model = new StudentListView(internStudent.intr_stdnt_Id, fullname, priOne, priTwo, priThree);
            return model;
        }

        private StudentListModel InCompletedItem(string id)
        {
            var allItem = db.InternLists.Where(x => x.UserId.Contains(id));
            List<int> incompletedItemsList= new List<int>();
            var incompleteListItem = new ListItemModel();
            InternStudentModel internStudent = db.InternStudentModels.Find(id);
            string fullname = internStudent.intr_stdnt_first_name + " " + internStudent.intr_stdnt_last_name;
            List<ListModel> inCompleted = new List<ListModel>();

            foreach (var item in allItem)
            {
                if(item.CompletetedItem=="No"||item.CompletetedItem==null)
                {
                    incompletedItemsList.Add(item.ListId);
                }
            }

             if(incompletedItemsList.Count()>0)
            {
                string completedItem = "No";
                foreach(var item in incompletedItemsList)
                {
                    var list = db.ListItem.Find(item);
                    ListModel modelList = new ListModel(list.ListId, list.ListName, list.ListLevel, list.ListDec, completedItem);
                    inCompleted.Add(modelList);
                }

               
            }
            StudentListModel model = new StudentListModel(internStudent.intr_stdnt_Id, fullname, inCompleted);
            return model;
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
