using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;
using System.Diagnostics;

namespace Publishers.Test
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void CanInsertAuthorIntoDatabase()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext> ();
            builder.UseSqlServer(
                                    "Data Source=(localdb)\\ProjectModels;Initial Catalog=PublisherAppTest;TrustServerCertificate=true;ApplicationIntent=ReadWrite;"
);
            using(var context = new ApplicationDbContext (builder.Options)) {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                var author = new Author { FirstName = "a" ,LastName="b"};
                context.Authors.Add(author);
                Debug.WriteLine($"Before: {author.Id}");
                context.SaveChanges();
                Debug.WriteLine($"After: {author.Id}");
                Assert.AreNotEqual( 0 , author.Id);

            }

        }
    }
}