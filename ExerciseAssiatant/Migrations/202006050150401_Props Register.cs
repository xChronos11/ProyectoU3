namespace ExerciseAssiatant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropsRegister : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Female", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Female");
        }
    }
}
