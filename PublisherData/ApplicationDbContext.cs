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
    }
}
