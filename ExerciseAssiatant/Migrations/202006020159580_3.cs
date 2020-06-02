namespace ExerciseAssiatant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UserExercises", name: "Admin_Id", newName: "Cliente_Id");
            RenameIndex(table: "dbo.UserExercises", name: "IX_Admin_Id", newName: "IX_Cliente_Id");
            AlterColumn("dbo.Exercises", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exercises", "Name", c => c.String());
            RenameIndex(table: "dbo.UserExercises", name: "IX_Cliente_Id", newName: "IX_Admin_Id");
            RenameColumn(table: "dbo.UserExercises", name: "Cliente_Id", newName: "Admin_Id");
        }
    }
}
