namespace HippoCampus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AspNetIdentity_RenameTables2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.StudentWorker", "wrkr_stdnt_phone");
            DropColumn("dbo.StudentWorker", "wrkr_stdnt_email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentWorker", "wrkr_stdnt_email", c => c.String());
            AddColumn("dbo.StudentWorker", "wrkr_stdnt_phone", c => c.String());
        }
    }
}
