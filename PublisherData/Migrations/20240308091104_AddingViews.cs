using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublisherData.Migrations
{
    /// <inheritdoc />
    public partial class AddingViews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE VIEW AuthorsByArtist
                as
                    Select Artists.FirstName + ' ' + Artists.LastName as Artist,
                             Authors.FirstName + ' ' + Authors.LastName as Author  
                FROM ARTISTS LEFT JOIN
                ArtistCover on Artists.ArtistID = artistCover.ArtistsArtistId LEFT JOIN
                Covers ON ArtistCover.CoversCoverID = Covers.CoverId LEFT JOIN
                Books ON Books.BookId = Covers.BookId LEFT JOIN
                Authors On Books.AuthorId = Authors.Id
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                    DROP VIEW AuthorsByArtist
");
        }
    }
}
