namespace VOD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDirector : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dirs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "DirId", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "Dir_Id", c => c.Int());
            CreateIndex("dbo.Movies", "Dir_Id");
            AddForeignKey("dbo.Movies", "Dir_Id", "dbo.Dirs", "Id");
            DropColumn("dbo.Movies", "Director");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Director", c => c.String(nullable: false));
            DropForeignKey("dbo.Movies", "Dir_Id", "dbo.Dirs");
            DropIndex("dbo.Movies", new[] { "Dir_Id" });
            DropColumn("dbo.Movies", "Dir_Id");
            DropColumn("dbo.Movies", "DirId");
            DropTable("dbo.Dirs");
            DropTable("dbo.Actors");
        }
    }
}
