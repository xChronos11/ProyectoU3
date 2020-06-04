namespace ExerciseAssiatant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migReq : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "title", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "text", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "imgUrl", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "imgUrl", c => c.String());
            AlterColumn("dbo.Posts", "text", c => c.String());
            AlterColumn("dbo.Posts", "title", c => c.String());
        }
    }
}
