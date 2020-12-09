namespace VOD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRental : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Rentals", new[] { "Customer_Id" });
            DropIndex("dbo.Rentals", new[] { "Movie_Id" });
            AddColumn("dbo.Rentals", "UserName", c => c.String());
            AddColumn("dbo.Rentals", "MovieName", c => c.String());
            DropColumn("dbo.Rentals", "DateReturned");
            DropColumn("dbo.Rentals", "Customer_Id");
            DropColumn("dbo.Rentals", "Movie_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "Movie_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Rentals", "Customer_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Rentals", "DateReturned", c => c.DateTime());
            DropColumn("dbo.Rentals", "MovieName");
            DropColumn("dbo.Rentals", "UserName");
            CreateIndex("dbo.Rentals", "Movie_Id");
            CreateIndex("dbo.Rentals", "Customer_Id");
            AddForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
