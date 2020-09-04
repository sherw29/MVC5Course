namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNumbAvailtoMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Byte(nullable: false));
            DropColumn("dbo.Movies", "MovieGenreId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "MovieGenreId", c => c.Byte(nullable: false));
            DropColumn("dbo.Movies", "NumberAvailable");
            DropColumn("dbo.Movies", "GenreId");
        }
    }
}
