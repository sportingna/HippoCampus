namespace HippoCampus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentWorkerModels",
                c => new
                    {
                        wrkr_stdnt_id = c.Int(nullable: false, identity: true),
                        wrkr_stdnt_first_name = c.String(),
                        wrkr_stdnt_last_name = c.String(),
                        wrkr_stdnt_phone = c.String(),
                        wrkr_stdnt_email = c.String(),
                        wrkr_stdnt_transport = c.String(),
                        wrkr_stdnt_availability = c.String(),
                    })
                .PrimaryKey(t => t.wrkr_stdnt_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StudentWorkerModels");
        }
    }
}
