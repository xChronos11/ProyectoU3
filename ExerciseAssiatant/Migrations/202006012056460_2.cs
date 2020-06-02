namespace ExerciseAssiatant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Admins", newName: "Clientes");
            AddColumn("dbo.UserExercises", "Admin_Id", c => c.Int());
            CreateIndex("dbo.UserExercises", "Admin_Id");
            AddForeignKey("dbo.UserExercises", "Admin_Id", "dbo.Clientes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserExercises", "Admin_Id", "dbo.Clientes");
            DropIndex("dbo.UserExercises", new[] { "Admin_Id" });
            DropColumn("dbo.UserExercises", "Admin_Id");
            RenameTable(name: "dbo.Clientes", newName: "Admins");
        }
    }
}
