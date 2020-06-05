namespace ExerciseAssiatant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mergecorrections : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ExerciseTypes", "Name", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ExerciseTypes", "Name", c => c.String(nullable: false));
        }
    }
}
