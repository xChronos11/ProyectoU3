namespace ExerciseAssiatant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Users", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.Users", "usrId", c => c.String());
            DropColumn("dbo.Users", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Users", "usrId");
            CreateIndex("dbo.Users", "ApplicationUser_Id");
            AddForeignKey("dbo.Users", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
