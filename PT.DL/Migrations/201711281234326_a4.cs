namespace PT.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Department");
            DropIndex("dbo.AspNetUsers", new[] { "DepartmentId" });
            AlterColumn("dbo.AspNetUsers", "DepartmentId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "DepartmentId");
            AddForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Department", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Department");
            DropIndex("dbo.AspNetUsers", new[] { "DepartmentId" });
            AlterColumn("dbo.AspNetUsers", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "DepartmentId");
            AddForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Department", "Id", cascadeDelete: true);
        }
    }
}
