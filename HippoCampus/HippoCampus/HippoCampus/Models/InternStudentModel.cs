using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HippoCampus.Models
{
    public class InternStudentModel
    {
       

        public InternStudentModel(string id, int bearpass_Id, string first_name, string last_name, string email, DateTime dob, string gender, DateTime date_time, string flight_num, string trans_req, string des_desc, string other_desc)
        {
            this.intr_stdnt_Id = id;
            this.bearpass_Id = bearpass_Id;
            this.intr_stdnt_first_name = first_name;
            this.intr_stdnt_last_name = last_name;
            this.intr_stdnt_email = email;
            this.intr_stdnt_dob = dob;
            this.intr_stdnt_gender = gender;
            this.intr_stdnt_arr_date_time = date_time;
            this.intr_stdnt_flight_num = flight_num;
            this.intr_stdnt_trans_req = trans_req;
            this.intr_stdnt_des_desc = des_desc;
            this.intr_stdnt_other_desc = other_desc;
        }
        [Key]
        public string intr_stdnt_Id { get; set; }

        [DisplayName("BearPass Number")]
        public int bearpass_Id { get; set; }
        [DisplayName("First Name")]
        public string intr_stdnt_first_name { get; set; }
        [DisplayName("Last Name")]
        public string intr_stdnt_last_name { get; set; }
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string intr_stdnt_email { get; set; }
        [DisplayName("Date of Birth")]
        public System.DateTime intr_stdnt_dob { get; set; }
        [DisplayName("Gender")]
        public string intr_stdnt_gender { get; set; }
        [DisplayName("Arrival Date/Time")]
        public System.DateTime intr_stdnt_arr_date_time { get; set; }
        [DisplayName("Flight Number")]
        public string intr_stdnt_flight_num { get; set; }
        [DisplayName("Transportation Request")]
        public string intr_stdnt_trans_req { get; set; }
        [DisplayName("Destination Description")]
        public string intr_stdnt_des_desc { get; set; }
        [DisplayName("Other Information")]
        public string intr_stdnt_other_desc { get; set; }
    }
}
