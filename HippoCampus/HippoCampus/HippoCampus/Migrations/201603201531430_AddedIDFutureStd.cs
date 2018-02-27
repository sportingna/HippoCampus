namespace HippoCampus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIDFutureStd : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.InternStudent");
            DropPrimaryKey("dbo.StudentWorker");
            AddColumn("dbo.InternStudent", "intr_stdnt_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.InternStudent", "bearpass_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.StudentWorker", "wrkr_stdnt_id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.InternStudent", "intr_stdnt_Id");
            AddPrimaryKey("dbo.StudentWorker", "wrkr_stdnt_id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.StudentWorker");
            DropPrimaryKey("dbo.InternStudent");
            AlterColumn("dbo.StudentWorker", "wrkr_stdnt_id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.InternStudent", "bearpass_Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.InternStudent", "intr_stdnt_Id");
            AddPrimaryKey("dbo.StudentWorker", "wrkr_stdnt_id");
            AddPrimaryKey("dbo.InternStudent", "bearpass_Id");
        }
    }
}
