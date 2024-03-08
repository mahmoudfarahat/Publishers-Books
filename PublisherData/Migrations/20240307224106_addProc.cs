using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublisherData.Migrations
{
    /// <inheritdoc />
    public partial class addProc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"

Create PROCEDURE dbo.AuthorsPublishedInYearRange
	@yearstart int,
	@yearend int
	As
	select DIstinct Authors.* from Authors
	Left join Books on Authors.Id = Books.AuthorId
	where Year(Books.PublishDate) >= @yearstart AND Year(Books.PublishDate) <= @yearend
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Drop PROCEDURE dbo.AuthorsPublishedInYearRange");
        }
    }
}
