namespace HippoCampus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigration4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FutureStudent",
                c => new
                    {
                        ftre_stdnt_id = c.String(nullable: false, maxLength: 128),
                        bearpass_Id = c.Int(nullable: false),
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
                .PrimaryKey(t => t.ftre_stdnt_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FutureStudent");
        }
    }
}
