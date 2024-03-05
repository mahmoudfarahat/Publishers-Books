using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;

namespace PublisherConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                context.Database.EnsureCreated();
            }

            GetAuthors();
            AddAuthor();
            GetAuthors();
            void AddAuthor()
            {
                var author = new Author { FirstName = "O33li", LastName = "Pob" };
                //author.Books.Add(new Book { Title ="dsadas",PublishDate =new DateOnly(2009,1,1) });
                //author.Books.Add(new Book { Title = "wwww", PublishDate = new DateOnly(2009, 1, 1) });

                using var context = new ApplicationDbContext(); 
                 context.Authors.Add(author);   
                context.SaveChanges();
            }
            void GetAuthors()
            {
                using var context = new ApplicationDbContext();
                //var authors = context.Authors.Include(a => a.Books).ToList();
                //foreach (var author in authors)
                //{
                //    Console.WriteLine(author.FirstName + " " + author.LastName);
                //    foreach (var book in author.Books)
                //    {
                //        Console.WriteLine(book.Title);
                //    }
                //}
            }
        }

      
    }
}
