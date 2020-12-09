namespace VOD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ActorId", c => c.Int(nullable: false));
            //DropColumn("dbo.Movies", " Actor_Id");
        }
        
        public override void Down()
        {
        }
    }
}
