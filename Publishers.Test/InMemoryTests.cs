using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PublisherConsole;
using PublisherData;
using PublisherDomain;
using System.Diagnostics;

namespace Publishers.Test
{
    [TestClass]
    public class InMemoryTests
    {
        [TestMethod]
        public void CanInsertAuthorIntoDatabase()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext> ();
            //            builder.UseSqlServer(
            //                                    "Data Source=(localdb)\\ProjectModels;Initial Catalog=PublisherAppTest;TrustServerCertificate=true;ApplicationIntent=ReadWrite;"
            //);
            var _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open ();

            builder.UseSqlite(_connection);

            using(var context = new ApplicationDbContext (builder.Options)) {
                //context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                var author = new Author { FirstName = "a" ,LastName="b"};
                context.Authors.Add(author);
                //Debug.WriteLine($"Before: {author.Id}");
                context.SaveChanges();
               // Debug.WriteLine($"After: {author.Id}");
                Assert.AreNotEqual( 0 , author.Id);

            }

        }

        [TestMethod]
        public void ChangeTrackerIdentifiesAddedAuthor()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite("Filename=:memory:");
            using var context = new ApplicationDbContext(builder.Options);
            var author = new Author { FirstName= "a" ,LastName="b"};    
            context.Authors.Add(author);
            Assert.AreEqual(EntityState.Added, context.Entry(author).State);
        }

        [TestMethod]
        public void InsertAuthorsReturnsCorrectResultNumber()
        {
            using ApplicationDbContext context = SetUpSQLiteMemoryContextWIthOpenConnection();
            var authors = new Dictionary<string, string>
            {
                { "a","b" },
                { "c","d" },

                { "d","e" }

            };

            var dl = new DataLogic(context);
            Assert.AreEqual(authors.Count, dl.ImportAuthors(authors));
        }

        private static ApplicationDbContext SetUpSQLiteMemoryContextWIthOpenConnection()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite("Filename=:memory:");
            var context = new ApplicationDbContext(builder.Options);
            context.Database.OpenConnection();
            context.Database.EnsureCreated();
            return context;
        }
    }
}