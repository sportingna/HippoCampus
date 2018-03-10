using HippoCampus.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HippoCampus.Models
{
    public class ListItemModel
    {
        [Key]
        public int ListId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string ListName { get; set; }
        [Required]
        [Display(Name = "Level")]
        public string ListLevel { get; set; }
        [Display(Name = "Description")]
        public string ListDec { get; set;}
        

    }

    public class ListItemCreateVeiw
    {
        public int ListId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string ListName { get; set; }
        [Required]
        [Display(Name = "Level")]
        public Level ListLevel { get; set; }
        [Display(Name = "Description")]
        public string ListDec { get; set; }
    }

    public class ListModel
    {
        

        public ListModel(int listId, string listName, string listLevel, string listDec)
        {
            ListId = listId;
            ListLevel = listLevel;
            ListName = listName;
            ListDec = listDec;
        }

        public ListModel(int listId,  string listName, string listLevel, string listDec, string completedItem) : this(listId, listName, listLevel,  listDec)
        {
            this.Checked = completedItem;
        }

        public int ListId { get; set; }
        
        [Display(Name = "Name")]
        public string ListName { get; set; }
        
        [Display(Name = "Level")]
        public string ListLevel { get; set; }
        [Display(Name = "Description")]
        public string ListDec { get; set; }
        [Display(Name = "Checked")]
        public string Checked { get; set; }

    }


    public class StudentLists
    {
        
        public StudentLists(string intr_stdnt_Id, int listId, string completed)
        {
            UserId = intr_stdnt_Id;
            ItemId = listId;
            CompletetedItem = completed;
        }

        [Key]
        public int ItemId { get; set; }
        public string UserId { get; set; }
        
        public string CompletetedItem { get; set; }

    }

    public class InternList
    {
        public InternList() { }

        public InternList(string intr_stdnt_Id, int listId, string completed)
        {
            this.UserId = intr_stdnt_Id;
            this.ListId = listId;
            this.CompletetedItem = completed;
        }

        [Key]
        public int Id { get; set; }
        public int ListId { get; set; }
        public string UserId { get; set; }
        public string CompletetedItem { get; set; }
    }

    public class StudentListView
    {
        public StudentListView() { }
        public StudentListView(string intr_stdnt_Id, string fullname, List<ListModel> priOne, List<ListModel> priTwo, List<ListModel> priThree)
        {
            UserId = intr_stdnt_Id;
            FullName = fullname;
            ListItemPriOne = priOne;
            ListItemPriTwo = priTwo;
            ListItemPriThree = priThree;
        }

        public string UserId { get; set; }
        public string FullName { get; set; }
        public IEnumerable<ListModel> ListItemPriOne { get; set; }
        public IEnumerable<ListModel> ListItemPriTwo { get; set; }
        public IEnumerable<ListModel> ListItemPriThree { get; set; }
        public string CompletetedItem { get; set; }
    }

    public class StudentListModel
    {
        
        public StudentListModel(string intr_stdnt_Id, string name, List<ListModel> list)
        {
            this.UserId = intr_stdnt_Id;
            this.InternName = name;
            this.List = list;
        }

       
        [Key]
        public string UserId { get; set; }
        public string InternName { get; set; }
        public IEnumerable<ListModel> List { get; set; }


    }
}