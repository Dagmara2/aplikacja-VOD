namespace VOD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FillActors : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Actors(Name) Values('Tom Hanks')");
            Sql("INSERT INTO Actors(Name) Values('Christian Bale')");
            Sql("INSERT INTO Actors(Name) Values('Eddie Murphy')");
            Sql("INSERT INTO Actors(Name) Values('Gary Oldman')");
            Sql("INSERT INTO Actors(Name) Values('Robin Williams')");
            Sql("INSERT INTO Actors(Name) Values('Denzel Washington')");
            Sql("INSERT INTO Actors(Name) Values('Robert De Niro')");
            Sql("INSERT INTO Actors(Name) Values('Joaquin Phoenix')");
            Sql("INSERT INTO Actors(Name) Values('Edward Norton')");
            Sql("INSERT INTO Actors(Name) Values('Morgan Freeman')");
            Sql("INSERT INTO Actors(Name) Values('Samuel L. Jackson')");
            Sql("INSERT INTO Actors(Name) Values('Al Pacino')");
            Sql("INSERT INTO Actors(Name) Values('Anthony Hopkins')");
            Sql("INSERT INTO Actors(Name) Values('Jack Nicholson')");
            Sql("INSERT INTO Actors(Name) Values('Daniel Day-Lewis')");
            Sql("INSERT INTO Actors(Name) Values('Marlon Brando')");
            Sql("INSERT INTO Actors(Name) Values('Dustin Hoffman')");
            Sql("INSERT INTO Actors(Name) Values('Michael Caine')");
            Sql("INSERT INTO Actors(Name) Values('Jeff Bridges')");
            Sql("INSERT INTO Actors(Name) Values('Charles Chaplin')");
            Sql("INSERT INTO Actors(Name) Values('Russell Crowe')");
            Sql("INSERT INTO Actors(Name) Values('Henry Fonda')");
            Sql("INSERT INTO Actors(Name) Values('Ian McKellen')");
            Sql("INSERT INTO Actors(Name) Values('Bruce Willis')");
            Sql("INSERT INTO Actors(Name) Values('Michael Douglas')");
            Sql("INSERT INTO Actors(Name) Values('Leonardo DiCaprio')");
            Sql("INSERT INTO Actors(Name) Values('Brad Pitt')");
            Sql("INSERT INTO Actors(Name) Values('Meryl Streep')");
            Sql("INSERT INTO Actors(Name) Values('Julie Andrews')");
            Sql("INSERT INTO Actors(Name) Values('Helen Mirren')");
            Sql("INSERT INTO Actors(Name) Values('Cate Blanchett')");
            Sql("INSERT INTO Actors(Name) Values('Kate Winslet')");
            Sql("INSERT INTO Actors(Name) Values('Emma Thompson')");
            Sql("INSERT INTO Actors(Name) Values('Julianne Moore')");
            Sql("INSERT INTO Actors(Name) Values('Frances McDormand')");
            Sql("INSERT INTO Actors(Name) Values('Nicole Kidman')");
            Sql("INSERT INTO Actors(Name) Values('Julia Roberts')");
            Sql("INSERT INTO Actors(Name) Values('Natalie Portman')");
            Sql("INSERT INTO Actors(Name) Values('Scarlett Johansson')");
            Sql("INSERT INTO Actors(Name) Values('Emma Stone')");
            Sql("INSERT INTO Actors(Name) Values('Angelina Jolie')");
            Sql("INSERT INTO Actors(Name) Values('Amy Adams')");
            Sql("INSERT INTO Actors(Name) Values('Keira Knightley')");
            Sql("INSERT INTO Actors(Name) Values('Charlize Theron')");
            Sql("INSERT INTO Actors(Name) Values('Helena Bonham Carter')");
            Sql("INSERT INTO Actors(Name) Values('Margot Robbie')");
            Sql("INSERT INTO Actors(Name) Values('Olivia Colman')");
            Sql("INSERT INTO Actors(Name) Values('Tilda Swinton')");
            Sql("INSERT INTO Actors(Name) Values('Emma Watson')");
            Sql("INSERT INTO Actors(Name) Values('Glenn Close')");
            Sql("INSERT INTO Actors(Name) Values('Uma Thurman')");
            Sql("INSERT INTO Actors(Name) Values('Renée Zellweger')");
            Sql("INSERT INTO Actors(Name) Values('Toni Collette')");
            Sql("INSERT INTO Actors(Name) Values('Jennifer Lawrence')");
            Sql("INSERT INTO Actors(Name) Values('Emily Blunt ')");
            Sql("INSERT INTO Actors(Name) Values('Saoirse Ronan ')");
            Sql("INSERT INTO Actors(Name) Values('Anne Hathaway ')");
            Sql("INSERT INTO Actors(Name) Values('Julie Walters ')");

            CreateTable(
                "dbo.MovieActors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Actor_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Actors", t => t.Actor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .Index(t => t.Actor_Id)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieActors", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.MovieActors", "Actor_Id", "dbo.Actors");
            DropIndex("dbo.MovieActors", new[] { "Movie_Id" });
            DropIndex("dbo.MovieActors", new[] { "Actor_Id" });
            DropTable("dbo.MovieActors");
        }
    }
}
