using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HippoCampus.Models
{
    public class GroupModel
    {
        [Key]
        public int GroupId { get; set; }
        [DisplayName("Group Name")]
        public string GroupName { get; set; }

    }

    public class GroupedUser
    {
        

        public GroupedUser(int groupId, string groupName, List<StudentWorkerModel> workerGroup, List<InternStudentModel> studentGroup)
        {
            GroupId = groupId;
            GroupName = groupName;
            Worker = workerGroup;
            Student = studentGroup;
        }

        public int GroupId { get; set; }
        [DisplayName("Group Name")]
        public string GroupName { get; set; }
        [DisplayName("Student Worker")]
        public IEnumerable<StudentWorkerModel> Worker { get; set; }
        [DisplayName("International Student")]
        public IEnumerable<InternStudentModel> Student { get; set; }
    }
    public class UserGroup
    {
        public UserGroup(int currentGroupID, string id)
        {
            GroupId = currentGroupID;
            UserId = id;
        }

        public UserGroup()
        { }

        [Key]        
        public string UserId { get; set; }
        
        public int GroupId { get; set; }
    }

    public class UngroupWorkerViewModel
    {
        public UngroupWorkerViewModel() { }
        public UngroupWorkerViewModel(int id, IEnumerable<StudentWorkerModel> worker )
        {
            GroupId = id;
            UngroupedWorker = worker;
        }
        
        public int GroupId { get; set; }
        public IEnumerable<StudentWorkerModel> UngroupedWorker { get; set; }
    }

    public class UngroupStudentViewModel
    {
        public UngroupStudentViewModel() { }
        public UngroupStudentViewModel(int id, IEnumerable<InternModel> student)
        {
            GroupId = id;
            UngroupedStudent = student;
        }

        public int GroupId { get; set; }
        public IEnumerable<InternModel> UngroupedStudent { get; set; }
    }

    public class UngroupStudent
    {
        public IEnumerable<InternStudentModel> UnGroupedInternStudent { get; set; }
    }

    public class CurrentGroupId
    {
        public CurrentGroupId() { }
        public CurrentGroupId(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}