namespace HippoCampus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idkmigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FutureStudent", "ftre_stdnt_first_name", c => c.String(nullable: false));
            AlterColumn("dbo.FutureStudent", "ftre_stdnt_last_name", c => c.String(nullable: false));
            AlterColumn("dbo.FutureStudent", "ftre_stdnt_email", c => c.String(nullable: false));
            AlterColumn("dbo.FutureStudent", "ftre_stdnt_gender", c => c.String(nullable: false));
            AlterColumn("dbo.FutureStudent", "ftre_stdnt_trans_req", c => c.String(nullable: false));
            AlterColumn("dbo.FutureStudent", "ftre_stdnt_des_desc", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FutureStudent", "ftre_stdnt_des_desc", c => c.String());
            AlterColumn("dbo.FutureStudent", "ftre_stdnt_trans_req", c => c.String());
            AlterColumn("dbo.FutureStudent", "ftre_stdnt_gender", c => c.String());
            AlterColumn("dbo.FutureStudent", "ftre_stdnt_email", c => c.String());
            AlterColumn("dbo.FutureStudent", "ftre_stdnt_last_name", c => c.String());
            AlterColumn("dbo.FutureStudent", "ftre_stdnt_first_name", c => c.String());
        }
    }
}
