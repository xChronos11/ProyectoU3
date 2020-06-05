namespace ExerciseAssiatant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a_mig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserExercises", "Usr_Id", c => c.Int());
            CreateIndex("dbo.UserExercises", "Usr_Id");
            AddForeignKey("dbo.UserExercises", "Usr_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserExercises", "Usr_Id", "dbo.Users");
            DropIndex("dbo.UserExercises", new[] { "Usr_Id" });
            DropColumn("dbo.UserExercises", "Usr_Id");
        }
    }
}
