using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;

namespace PublisherConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {




            ApplicationDbContext context = new ();

            var artistA = context.Artists.Find(1);
            var cover = new Cover { DesignIdeas = "sdsads" };
            cover.Artists.Add(artistA);
            context.ChangeTracker.DetectChanges();
            context.Covers.Add(cover);
            context.SaveChanges();



            //context.Authors.ToList();
            //var author = context.Authors.Find(1);

            //var unKnownTypes = context.Authors.Select(a => new
            //{
            //    a.Id,
            //    Name = a.FirstName.First() + " " + a.LastName,
            //      a.Books 
            //}).ToList();
            //foreach (var item in author.Books)
            //{
            //    Console.WriteLine(item.Title);
            //}
            var author = context.Authors.Find(1);

            var books = author.Books.Count();
            
            Console.WriteLine(books);   
            var debugview = context.ChangeTracker.DebugView.ShortView;
                

            //CoordinateRetrieveAndUpdateAuthor();
            //void CoordinateRetrieveAndUpdateAuthor()
            //{
            //     var author = FindThatAuthor(3);
            //    if(author?.FirstName == "Mahmoud")
            //    {
            //        author.FirstName = "Olw";
            //        SaveThatAuthor(author);
            //    }
            //     //var author = new Author { FirstName = "O33li", LastName = "Pob" };
            //    //author.Books.Add(new Book { Title ="dsadas",PublishDate =new DateOnly(2009,1,1) });
            //    //author.Books.Add(new Book { Title = "wwww", PublishDate = new DateOnly(2009, 1, 1) });

            //    using var context = new ApplicationDbContext(); 
            //     context.Authors.Add(author);   
            //    context.SaveChanges();
            //}
            //void GetAuthors()
            //{
            //    using var context = new ApplicationDbContext();
            //    //var authors = context.Authors.Include(a => a.Books).ToList();
            //    //foreach (var author in authors)
            //    //{
            //    //    Console.WriteLine(author.FirstName + " " + author.LastName);
            //    //    foreach (var book in author.Books)
            //    //    {
            //    //        Console.WriteLine(book.Title);
            //    //    }
            //    //}
            // }

            //Author FindThatAuthor(int authorId)
            //{
            //    using var shortLivedContext = new ApplicationDbContext();
            //    return shortLivedContext.Authors.Find(authorId);
            //}

            //void SaveThatAuthor(Author author)
            //{
            //    using var anotherShortLivedContext = new ApplicationDbContext();
            //    anotherShortLivedContext.Authors.Update(author);
            //    anotherShortLivedContext.SaveChanges();
            //}














            //ApplicationDbContext _context = new();


            //RetrieveAndUpdateMultipleAuthors();
            //void RetrieveAndUpdateMultipleAuthors()
            //{
            //    var lermanAuthors = _context.Authors.Where(a => a.LastName == "Farahat").ToList();
            //    foreach (var la in lermanAuthors)
            //    {
            //        la.LastName = "Oli";
            //    }
            //    Console.WriteLine($"Before:\r\n{_context.ChangeTracker.DebugView.ShortView}");
            //    _context.ChangeTracker.DetectChanges();
            //    Console.WriteLine($"After:\r\n{_context.ChangeTracker.DebugView.ShortView}");
            //    _context.SaveChanges();
            //}
            //GetAuthors();
            //AddSomeMoreAuthors();

            //void AddSomeMoreAuthors()
            //{

            //    var author = new Author
            //    {
            //        FirstName = "3",
            //        LastName = "Farahat"
            //    };
            //    //_context.Authors.Add(new Author { FirstName = "1", LastName = "Farahat" });
            //    //_context.Authors.Add(new Author { FirstName = "2", LastName = "Farahat" });
            //    //_context.Authors.Add(new Author { FirstName = "3", LastName = "Farahat" });
            //    _context.Authors.Add(author);
            //    _context.SaveChanges();

            //    _context.SaveChanges();
            //}
            //skipAndTakeAuthors();
            //void skipAndTakeAuthors()
            //{
            //    var groupSize = 2;
            //    for (int i = 0; i < 5; i++)
            //    {
            //        var authors = _context.Authors.Skip(groupSize * i).Take(groupSize).ToList();
            //        Console.WriteLine($"Group {i}:");
            //        foreach (var author in authors)
            //        {
            //            Console.WriteLine($"{author.FirstName}{author.LastName}");
            //        }


            //    }
            //}

            //void GetAuthors()
            //{

                //var authors =_context.Authors.Where( a => EF.Functions.Like(a.LastName,"O%")).ToList();  // T SQL sytax

                //var filter = "O%";
                //var authors1 = _context.Authors.Where(a => EF.Functions.Like(a.LastName,filter)).ToList();  // T SQL sytax


                //var authors = _context.Authors.Where(a => a.FirstName == "O33li").ToList();

                //var firstName = "O33li";
                //var authors2 = _context.Authors.Where(a => a.FirstName == firstName).ToList();




                //var authors = _context.Authors.Include(a => a.Books).ToList();
                //foreach (var author in authors)
                //{
                //    Console.WriteLine(author.FirstName + " " + author.LastName);
                //    foreach (var book in author.Books)
                //    {
                //        Console.WriteLine(book.Title);
                //    }
                //}
            //}



            //using (ApplicationDbContext context = new ApplicationDbContext())
            //{
            //    context.Database.EnsureCreated();
            //}

            //GetAuthors();
            //AddAuthor();
            //void AddAuthor()
            //{
            //    var author = new Author { FirstName = "O33li", LastName = "Pob" };
            //    author.Books.Add(new Book { Title ="dsadas",PublishDate =new DateOnly(2009,1,1) });
            //    author.Books.Add(new Book { Title = "wwww", PublishDate = new DateOnly(2009, 1, 1) });

            //    using var context = new ApplicationDbContext(); 
            //     context.Authors.Add(author);   
            //    context.SaveChanges();
            //}
        }


    }
}
