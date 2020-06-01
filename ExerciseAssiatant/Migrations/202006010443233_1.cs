namespace ExerciseAssiatant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Cal4Hour = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserExercises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExerciseId = c.Int(nullable: false),
                        Duration = c.Time(nullable: false, precision: 7),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exercises", t => t.ExerciseId, cascadeDelete: true)
                .Index(t => t.ExerciseId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Birthdate = c.DateTime(nullable: false),
                        Male = c.Boolean(nullable: false),
                        Height = c.Single(nullable: false),
                        Weight = c.Single(nullable: false),
                        BMI = c.Single(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserExercises", "ExerciseId", "dbo.Exercises");
            DropForeignKey("dbo.Admins", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Users", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.UserExercises", new[] { "ExerciseId" });
            DropIndex("dbo.Admins", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.UserExercises");
            DropTable("dbo.Exercises");
            DropTable("dbo.Admins");
        }
    }
}
