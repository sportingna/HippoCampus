namespace HippoCampus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AspNetIdentity_RenameTables1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.FutureStudentModels", newName: "FutureStudent");
            RenameTable(name: "dbo.InternStudentModels", newName: "InternStudent");
            RenameTable(name: "dbo.StudentWorkerModels", newName: "StudentWorker");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.StudentWorker", newName: "StudentWorkerModels");
            RenameTable(name: "dbo.InternStudent", newName: "InternStudentModels");
            RenameTable(name: "dbo.FutureStudent", newName: "FutureStudentModels");
        }
    }
}
