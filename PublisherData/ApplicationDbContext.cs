using Microsoft.EntityFrameworkCore;
using PublisherDomain;

namespace PublisherData
{
    public class ApplicationDbContext :DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\ProjectModels;Initial Catalog=PublisherApp;TrustServerCertificate=true;ApplicationIntent=ReadWrite;"
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new Author { Id = 1, FirstName = "Mahmoud", LastName = "Farahat" });

            var authorList = new Author[]
            {
                new Author { Id = 2, FirstName = "Ali", LastName = "Ahmed" },
                new Author { Id = 3, FirstName = "Omar", LastName = "Tamer" },
                new Author { Id = 4, FirstName = "Peter", LastName = "Magdy" },
                new Author { Id = 5, FirstName = "Li", LastName = "Loe" }
            };
            modelBuilder.Entity<Author>()
                .HasMany<Book>()
                .WithOne();

            modelBuilder.Entity<Author>().HasData(authorList);

        }
    }
}
