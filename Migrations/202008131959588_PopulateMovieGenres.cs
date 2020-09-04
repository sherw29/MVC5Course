namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovieGenres : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT MovieGenres ON");
            Sql("INSERT INTO MovieGenres(Id,Genre) VALUES (1,'Action')");
            Sql("INSERT INTO MovieGenres(Id,Genre) VALUES (2,'Horror')");
            Sql("INSERT INTO MovieGenres(Id,Genre) VALUES (3,'Comedy')");
            Sql("INSERT INTO MovieGenres(Id,Genre) VALUES (4,'Thriller')");
            Sql("INSERT INTO MovieGenres(Id,Genre) VALUES (5,'Fiction')");
            Sql("INSERT INTO MovieGenres(Id,Genre) VALUES (6,'Documentary')");
            Sql("INSERT INTO MovieGenres(Id,Genre) VALUES (7,'Biopic')");
            Sql("SET IDENTITY_INSERT MovieGenres OFF");

        }

        public override void Down()
        {
        }
    }
}
