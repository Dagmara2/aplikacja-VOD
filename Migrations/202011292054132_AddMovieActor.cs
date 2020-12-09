namespace VOD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieActor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Dir_Id", "dbo.Dirs");
            DropIndex("dbo.Movies", new[] { "Dir_Id" });
            DropColumn("dbo.Movies", "Dir_Id");
            AlterColumn("dbo.Movies", "DirId", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "DirId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "DirId");
            AddForeignKey("dbo.Movies", "DirId", "dbo.Dirs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "DirId", "dbo.Dirs");
            DropIndex("dbo.Movies", new[] { "DirId" });
            AlterColumn("dbo.Movies", "DirId", c => c.Int());
            AlterColumn("dbo.Movies", "DirId", c => c.Byte(nullable: false));
            RenameColumn(table: "dbo.Movies", name: "DirId", newName: "Dir_Id");
            AddColumn("dbo.Movies", "DirId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "Dir_Id");
            AddForeignKey("dbo.Movies", "Dir_Id", "dbo.Dirs", "Id");
        }
    }
}
