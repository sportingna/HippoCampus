namespace HippoCampus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seperatedDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FutureStudent", "ftre_stdnt_arr_date", c => c.DateTime(nullable: false));
            AddColumn("dbo.FutureStudent", "ftre_stdnt_arr_time", c => c.DateTime(nullable: false));
            DropColumn("dbo.FutureStudent", "ftre_stdnt_arr_date_time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FutureStudent", "ftre_stdnt_arr_date_time", c => c.DateTime(nullable: false));
            DropColumn("dbo.FutureStudent", "ftre_stdnt_arr_time");
            DropColumn("dbo.FutureStudent", "ftre_stdnt_arr_date");
        }
    }
}
