using System.Web.UI.WebControls;
using Vidly.Models;

namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtendingMovieModel2 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO  Movies(Name, Genre_Id, ReleaseDate, AddedDate, NumberInStock) VALUES('Kill Bil', 1, '05/29/2005 05:50', '07/29/2005 09:09', 5)");
            Sql("INSERT INTO  Movies(Name, Genre_Id, ReleaseDate, AddedDate, NumberInStock) VALUES('Serenity', 5, '05/20/2007 05:50', '07/29/2007 09:09', 5)");
            Sql("INSERT INTO  Movies(Name, Genre_Id, ReleaseDate, AddedDate, NumberInStock) VALUES('Hancock', 2, '05/20/2009 05:50', '07/29/2009 09:09', 5)");
            Sql("INSERT INTO  Movies(Name, Genre_Id, ReleaseDate, AddedDate, NumberInStock) VALUES('Showshank', 3 , '05/20/2009 05:50', '07/29/2009 09:09', 5)");
            Sql("INSERT INTO  Movies(Name, Genre_Id, ReleaseDate, AddedDate, NumberInStock) VALUES('Exorcism of Emilly Rose', 4 , '05/20/2001 05:50', '07/29/2001 09:09', 5)");
        }
        
        public override void Down()
        {
        }
    }
}
