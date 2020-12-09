namespace VOD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixActorsInMovies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActorsInMovies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActorName = c.String(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "Actor_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "ActorId");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "ActorId");
            DropTable("dbo.ActorsInMovies");
        }
    }
}
