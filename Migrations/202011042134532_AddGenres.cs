namespace VOD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Id, Name) Values(1, 'Drama')");
            Sql("INSERT INTO Genres(Id, Name) Values(2, 'Comedy')");
            Sql("INSERT INTO Genres(Id, Name) Values(3, 'Romance')");
            Sql("INSERT INTO Genres(Id, Name) Values(4, 'Action')");
            Sql("INSERT INTO Genres(Id, Name) Values(5, 'Documentary')");
            Sql("INSERT INTO Genres(Id, Name) Values(6, 'Musical')");
            Sql("INSERT INTO Genres(Id, Name) Values(7, 'Thriller')");
            Sql("INSERT INTO Genres(Id, Name) Values(8, 'Animated')");
            Sql("INSERT INTO Genres(Id, Name) Values(9, 'Family')");
            Sql("INSERT INTO Genres(Id, Name) Values(10, 'Historical')");
            Sql("INSERT INTO Genres(Id, Name) Values(11, 'Sci-fi/Fantasy')");
            Sql("INSERT INTO Genres(Id, Name) Values(12, 'Horror')");
        }
        
        public override void Down()
        {
        }
    }
}
