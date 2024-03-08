using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using PublisherData;
using PublisherDomain;
namespace PublishersAPI;

public static class AuthorEndpoints
{
    public static void MapAuthorEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Author").WithTags(nameof(Author));

        group.MapGet("/", async (ApplicationDbContext db) =>
        {
            return await db.Authors.Include(a => a.Books).AsNoTracking().ToListAsync();
        })
        .WithName("GetAllAuthors")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<AuthorDto>, NotFound>> (int id, ApplicationDbContext db) =>
        {
            return await db.Authors.AsNoTracking()
            .Where(model => model.Id == id)
            .Select(a => new AuthorDto(a.Id,a.FirstName,a.LastName))
                .FirstOrDefaultAsync()
                is AuthorDto model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetAuthorById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, AuthorDto authorDto, ApplicationDbContext db) =>
        {
            var affected = await db.Authors
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    //.SetProperty(m => m.Id, authorDto.Id)
                    .SetProperty(m => m.FirstName, authorDto.FirstName)
                    .SetProperty(m => m.LastName, authorDto.LastName)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateAuthor")
        .WithOpenApi();

        group.MapPost("/", async (AuthorDto authorDto, ApplicationDbContext db) =>
        {
            var author = new Author { FirstName = authorDto.FirstName , LastName = authorDto.LastName };
            db.Authors.Add(author);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Author/{author.Id}",
                new AuthorDto(author.Id,author.FirstName,author.LastName)
                );
        })
        .WithName("CreateAuthor")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, ApplicationDbContext db) =>
        {
            var affected = await db.Authors
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteAuthor")
        .WithOpenApi();
    }
}
