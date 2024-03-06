using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PublisherDomain;

namespace PublisherData
{
    public class ApplicationDbContext :DbContext
    {
        //private StreamWriter _streamWriter = new StreamWriter("EFCoreLogs.txt",append:true);
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Cover> Covers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\ProjectModels;Initial Catalog=PublisherApp;TrustServerCertificate=true;ApplicationIntent=ReadWrite;"
                )
                //.UseLazyLoadingProxies()
                 .LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Command.Name} ,LogLevel.Information)
                //.LogTo(_streamWriter.WriteLine)
                .EnableSensitiveDataLogging();
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

            //modelBuilder.Entity<Author>()
            //    .HasMany<Book>()
            //    .WithOne()
            //    .HasForeignKey(a => a.AuthorFK);

            //modelBuilder.Entity<Author>()
            //    .HasMany(a => a.Books)
            //    .WithOne(b => b.Author)
            //    .HasForeignKey(a => a.AuthorFK)
            //    .HasForeignKey('AuthorFK')
            //    .IsRequired(false);
 
            modelBuilder.Entity<Author>().HasData(authorList);

            var someArtist = new Artist[]
            {
                new Artist{ArtistId = 1 , FirstName = "Pablo" , LastName="Picasso"},
                new Artist{ArtistId = 2 , FirstName = "Mahmoud" , LastName="Picasso"},
                new Artist{ArtistId = 3 , FirstName = "Farahat" , LastName="Picasso"},

            };
            modelBuilder.Entity<Artist>().HasData(someArtist);

            var someCovers = new Cover[]
            {
                new Cover{CoverId = 1 , DesignIdeas = "Pablo" , DigitalOnly=false},
                new Cover{CoverId = 2 , DesignIdeas = "Pablo" , DigitalOnly=false},
                new Cover{CoverId =3 , DesignIdeas = "Pablo" , DigitalOnly=false},

            };
            modelBuilder.Entity<Cover>().HasData(someCovers);



            modelBuilder.Entity<Artist>()
                .HasMany(a => a.Covers)
                .WithMany(c => c.Artists)
                .UsingEntity<CoverAssignment>(
                b =>
                {
                    b.Property(ca => ca.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");
                    b.ToTable("ArtistCover");
                    b.Property(ca => ca.CoverId).HasColumnName("CoversCoverId");
                    b.Property(ca => ca.ArtistId).HasColumnName("ArtistsArtistId");

                }
                );
        }

        public override void Dispose()
        {
            //_streamWriter.Dispose();
            base.Dispose();
        }
    }
}
