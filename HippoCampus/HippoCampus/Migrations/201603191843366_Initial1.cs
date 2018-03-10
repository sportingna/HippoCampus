namespace HippoCampus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FutureStudentModels",
                c => new
                    {
                        bearpass_Id = c.Int(nullable: false, identity: true),
                        ftre_stdnt_first_name = c.String(),
                        ftre_stdnt_last_name = c.String(),
                        ftre_stdnt_email = c.String(),
                        ftre_stdnt_dob = c.DateTime(nullable: false),
                        ftre_stdnt_gender = c.String(),
                        ftre_stdnt_arr_date_time = c.DateTime(nullable: false),
                        ftre_stdnt_flight_num = c.String(),
                        ftre_stdnt_trans_req = c.String(),
                        ftre_stdnt_des_desc = c.String(),
                        ftre_stdnt_other_desc = c.String(),
                    })
                .PrimaryKey(t => t.bearpass_Id);
            
            CreateTable(
                "dbo.InternStudentModels",
                c => new
                    {
                        bearpass_Id = c.Int(nullable: false, identity: true),
                        intr_stdnt_first_name = c.String(),
                        intr_stdnt_last_name = c.String(),
                        intr_stdnt_email = c.String(),
                        intr_stdnt_dob = c.DateTime(nullable: false),
                        intr_stdnt_gender = c.String(),
                        intr_stdnt_arr_date_time = c.DateTime(nullable: false),
                        intr_stdnt_flight_num = c.String(),
                        intr_stdnt_trans_req = c.String(),
                        intr_stdnt_des_desc = c.String(),
                        intr_stdnt_other_desc = c.String(),
                    })
                .PrimaryKey(t => t.bearpass_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InternStudentModels");
            DropTable("dbo.FutureStudentModels");
        }
    }
}
