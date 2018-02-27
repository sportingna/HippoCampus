using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HippoCampus.Models
{

    public class FutureStudentModel
    {
        public FutureStudentModel(string id, int bearpass_Id, string ftre_stdnt_first_name, string ftre_stdnt_last_name, string ftre_stdnt_email, DateTime ftre_stdnt_dob, string ftre_stdnt_gender, DateTime ftre_stdnt_arr_date, DateTime ftre_stdnt_arr_time, string ftre_stdnt_flight_num, string ftre_stdnt_trans_req, string ftre_stdnt_des_desc, string ftre_stdnt_other_desc)
        {
            this.ftre_stdnt_id = id;
            this.bearpass_Id = bearpass_Id;
            this.ftre_stdnt_first_name = ftre_stdnt_first_name;
            this.ftre_stdnt_last_name = ftre_stdnt_last_name;
            this.ftre_stdnt_email = ftre_stdnt_email;
            this.ftre_stdnt_dob = ftre_stdnt_dob;
            this.ftre_stdnt_gender = ftre_stdnt_gender;
            this.ftre_stdnt_arr_date = ftre_stdnt_arr_date;
            this.ftre_stdnt_arr_time = ftre_stdnt_arr_time;
            this.ftre_stdnt_flight_num = ftre_stdnt_flight_num;
            this.ftre_stdnt_trans_req = ftre_stdnt_trans_req;
            this.ftre_stdnt_des_desc = ftre_stdnt_des_desc;
            this.ftre_stdnt_other_desc = ftre_stdnt_other_desc;
        }
        public FutureStudentModel()
        { }

        [Key]
        public string ftre_stdnt_id { get; set; }

        [Required]
        [DisplayName("BearPass Number")]
        public int bearpass_Id { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string ftre_stdnt_first_name { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string ftre_stdnt_last_name { get; set; }

        [Required]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string ftre_stdnt_email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        public System.DateTime ftre_stdnt_dob { get; set; }

        [Required]
        [DisplayName("Gender")]
        public string ftre_stdnt_gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Arrival Date")]
        public System.DateTime ftre_stdnt_arr_date { get; set; }


        [Required]
        [DataType(DataType.Time)]
        [DisplayName("Arrival Time")]
        public System.DateTime ftre_stdnt_arr_time { get; set; }

        [DisplayName("Flight Number")]
        public string ftre_stdnt_flight_num { get; set; }

        [Required]
        [DisplayName("Transportation Request")]
        public string ftre_stdnt_trans_req { get; set; }

        [Required]
        [DisplayName("Destination Description")]
        public string ftre_stdnt_des_desc { get; set; }

        [DisplayName("Other Information")]
        public string ftre_stdnt_other_desc { get; set; }
    }
}


