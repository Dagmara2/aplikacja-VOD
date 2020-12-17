namespace VOD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropForeignKey("dbo.MovieActors", "Actor_Id", "dbo.Actors");
            DropForeignKey("dbo.MovieActors", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            DropIndex("dbo.MovieActors", new[] { "Actor_Id" });
            DropIndex("dbo.MovieActors", new[] { "Movie_Id" });
            DropTable("dbo.Actors");
            DropTable("dbo.Customers");
            DropTable("dbo.MembershipTypes");
            DropTable("dbo.MovieActors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MovieActors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Actor_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                        MembershipName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        SubscribedToNewsletter = c.Boolean(nullable: false),
                        MembershipTypeId = c.Byte(nullable: false),
                        Birthdate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.MovieActors", "Movie_Id");
            CreateIndex("dbo.MovieActors", "Actor_Id");
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.MovieActors", "Movie_Id", "dbo.Movies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MovieActors", "Actor_Id", "dbo.Actors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
    }
}
