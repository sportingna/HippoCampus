using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HippoCampus.Models
{
    
    public  class StudentWorkerModel
    {
         public StudentWorkerModel ()
        { }

        public StudentWorkerModel(string id, string wrkr_stdnt_first_name, string wrkr_stdnt_last_name, string wrkr_stdnt_transport, string wrkr_stdnt_availability)
        {
            this.wrkr_stdnt_id = id;
            this.wrkr_stdnt_first_name = wrkr_stdnt_first_name;
            this.wrkr_stdnt_last_name = wrkr_stdnt_last_name;
            this.wrkr_stdnt_transport = wrkr_stdnt_transport;
            this.wrkr_stdnt_availability = wrkr_stdnt_availability;
        }

        [Key]
        public string wrkr_stdnt_id { get; set; }
        [DisplayName("First Name")]
        public string wrkr_stdnt_first_name { get; set; }
        [DisplayName("Last Name")]
        public string wrkr_stdnt_last_name { get; set; }

       
        [DisplayName("Drive")]
        public string wrkr_stdnt_transport { get; set; }
        [DisplayName("Availability")]
        public string wrkr_stdnt_availability { get; set; }

        

        public bool IsDrive()
        {
            bool flag;

            if(wrkr_stdnt_transport=="Yes")
            {
                flag = true;
            }
            else
            {
                flag = false;
            }

            return flag;
        }

        public bool IsAvailable()
        {
            bool flag;
            if (wrkr_stdnt_availability == "Yes")
            {
                flag = true;
            }
            else
            {
                flag = false;
            }

            return flag;
        }
    }
}
