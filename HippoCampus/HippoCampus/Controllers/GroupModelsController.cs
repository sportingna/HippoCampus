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
    public class GroupModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public CurrentGroupId groupId;

        // GET: GroupModels
        public ActionResult Index()
        {
            return View(db.Group.ToList());
        }

        // GET: GroupModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupModel groupModel = db.Group.Find(id);
            var allWorkers = db.Users.Where(x => x.Roles.Select(role => role.RoleId).Contains("wrkr")).ToList();
            var userGrouped = db.UserGroup.ToList();
            
            var workerGroup = new List<StudentWorkerModel>();
            var studentGroup = new List<InternStudentModel>();

            if (groupModel == null)
            {
                return HttpNotFound();
            }

            foreach (var item in userGrouped)
            {
                if (item.GroupId!=id)
                {
                    userGrouped.Remove(item);
                }
            }

            foreach (var item in userGrouped)
            {
                if (allWorkers.Any(d => d.Id == item.UserId))
                {
                     var studentWorker = db.StudentWorker.Find(item.UserId);
                     workerGroup.Add(studentWorker);
                 }
                 else
                 {
                     var student = db.InternStudentModels.Find(item.UserId);
                     studentGroup.Add(student);
                 }
             }
            
            GroupedUser groupDetailView = new GroupedUser(groupModel.GroupId, groupModel.GroupName, workerGroup, studentGroup);

            return View(groupDetailView);
        }

        // GET: GroupModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GroupModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupId,GroupName")] GroupModel groupModel)
        {
            if (ModelState.IsValid)
            {
                db.Group.Add(groupModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(groupModel);
        }

        // GET: GroupModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupModel groupModel = db.Group.Find(id);
            if (groupModel == null)
            {
                return HttpNotFound();
            }
            return View(groupModel);
        }

        // POST: GroupModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupId,GroupName")] GroupModel groupModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(groupModel);
        }

        // GET: GroupModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupModel groupModel = db.Group.Find(id);
            if (groupModel == null)
            {
                return HttpNotFound();
            }
            return View(groupModel);
        }

        // POST: GroupModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupModel groupModel = db.Group.Find(id);
            var groupedUser = db.UserGroup.Where(x => x.GroupId.Equals(id));

            foreach(var user in groupedUser)
            {
                db.UserGroup.Remove(user);
            }

            db.Group.Remove(groupModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Post:
        
        public ActionResult AddWorker(int id)
        {
            groupId = new CurrentGroupId(id);
            

            GroupModel groupModel = db.Group.Find(id);
            if (groupModel == null)
            {
                return HttpNotFound();
            }
            UngroupWorkerViewModel unGroupWorker = UnGroWorkers(id);
           
            return View(unGroupWorker);
        }

       

        public ActionResult AddWorkerGroup(string Id, int groupId)
        {
            
            UserGroup addWorker = new UserGroup(groupId, Id);
            db.UserGroup.Add(addWorker);
            db.SaveChanges();



            return RedirectToAction("Index");
        }
        

        public ActionResult AddStudent(int id)
        {
            groupId = new CurrentGroupId(id);


            GroupModel groupModel = db.Group.Find(id);
            if (groupModel == null)
            {
                return HttpNotFound();
            }
            UngroupStudentViewModel unGroupWorker = UnGroStudent(id);

            return View(unGroupWorker);
        }



        public ActionResult AddStudentGroup(string Id, int groupId)
        {

            UserGroup addStudent = new UserGroup(groupId, Id);
            db.UserGroup.Add(addStudent);
            db.SaveChanges();



            return RedirectToAction("Index");
        }
       public ActionResult RemoveUserView(string Id, int groupId)
        {
            var user = db.UserGroup.Find(Id);
            db.UserGroup.Remove(user);
            db.SaveChanges();

            return RedirectToAction("Details", new { id = groupId });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public UngroupWorkerViewModel UnGroWorkers(int currentGroupID)
        {
            var allWorkers = db.Users.Where(x => x.Roles.Select(role => role.RoleId).Contains("wrkr")).ToList();
            var allGroupMem = db.UserGroup.ToList();
            var unGroupWorker = new List<StudentWorkerModel>();

            if (allGroupMem.Count == 0)
            {
                unGroupWorker = db.StudentWorker.ToList();
            }

            foreach (var worker in allWorkers)
            {
                if (allGroupMem.Any(d => d.UserId.Contains(worker.Id)))
                {
                    
                }
                else
                {
                    var studentWorker = db.StudentWorker.Find(worker.Id);
                    unGroupWorker.Add(studentWorker);
                }
            }
            
            var viewModel = new UngroupWorkerViewModel { GroupId = currentGroupID, UngroupedWorker = unGroupWorker.ToList() };
            return viewModel;
        }

        public UngroupStudentViewModel UnGroStudent(int currentGroupID)
        {
            var allStudent = db.Users.Where(x => x.Roles.Select(role => role.RoleId).Contains("intr")).ToList();
            var allGroupMem = db.UserGroup.ToList();
            var unGroupStudent = new List<InternModel>();

            if (allGroupMem.Count == 0)
            {
                var studnet = db.InternStudentModels.ToList();
                foreach(var stud in studnet)
                {
                    var studModel = new InternModel(stud.intr_stdnt_Id, stud.intr_stdnt_first_name, stud.intr_stdnt_last_name);
                    unGroupStudent.Add(studModel);
                }
            }

            foreach (var s in allStudent)
            {
                if (allGroupMem.Any(d => d.UserId.Contains(s.Id)))
                {
                   
                }
                else
                {
                    var student = db.InternStudentModels.Find(s.Id);
                    var studModel = new InternModel(student.intr_stdnt_Id, student.intr_stdnt_first_name, student.intr_stdnt_last_name);
                    unGroupStudent.Add(studModel);
                }
            }

            var viewModel = new UngroupStudentViewModel { GroupId = currentGroupID, UngroupedStudent = unGroupStudent.ToList() };
            return viewModel;
        }
    }
}
