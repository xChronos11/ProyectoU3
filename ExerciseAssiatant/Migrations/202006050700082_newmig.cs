namespace ExerciseAssiatant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserExercises", "Cliente_Id", "dbo.Clientes");
            DropIndex("dbo.UserExercises", new[] { "Cliente_Id" });
            AddColumn("dbo.UserExercises", "UsuarioId", c => c.String());
            DropColumn("dbo.UserExercises", "Cliente_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserExercises", "Cliente_Id", c => c.Int());
            DropColumn("dbo.UserExercises", "UsuarioId");
            CreateIndex("dbo.UserExercises", "Cliente_Id");
            AddForeignKey("dbo.UserExercises", "Cliente_Id", "dbo.Clientes", "Id");
        }
    }
}
