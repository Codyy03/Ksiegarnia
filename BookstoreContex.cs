using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ksiegarnia.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Ksiegarnia
{
    public class BookstoreContex : DbContext
    {
        public static BookstoreContex context = new BookstoreContex(ConnectionStringManager.ContextOptions());
        private readonly string connectionString;
        public BookstoreContex(DbContextOptions<BookstoreContex> options) : base(options) { }
        public BookstoreContex(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Dodawanie danych początkowych do tabeli "Ksiazki"
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    ID = 1,
                    Title = "Pan Tadeusz",
                    Genre = "Epopeja",
                    Description = "Najważniejsze dzieło polskiego romantyzmu.",
                    Price = 39.99m,
                    Language = "Polski",
                    Pages = 320,
                    CoverName = "pan_tadeusz.jpg",
                    AuthorID = 1
                },
                new Book
                {
                    ID = 2,
                    Title = "To",
                    Genre = "Horror",
                    Description = "Przerażająca historia o kosmicznym złu w małym miasteczku.",
                    Price = 49.99m,
                    Language = "Angielski",
                    Pages = 512,
                    CoverName = "to.jpg",
                    AuthorID = 2
                },
                new Book
                {
                    ID = 3,
                    Title = "Harry Potter i Kamień Filozoficzny",
                    Genre = "Fantasy",
                    Description = "Pierwsza część serii o młodym czarodzieju.",
                    Price = 45.50m,
                    Language = "Polski",
                    Pages = 328,
                    CoverName = "harry_potter.jpg",
                    AuthorID = 3
                },
                new Book
                {
                    ID = 4,
                    Title = "Ostatnie życzenie",
                    Genre = "Fantasy",
                    Description = "Pierwszy zbiór opowiadań o Wiedźminie Geralcie.",
                    Price = 42.00m,
                    Language = "Polski",
                    Pages = 288,
                    CoverName = "wiedzmin.jpg",
                    AuthorID = 4
                },
                new Book
                {
                    ID = 5,
                    Title = "Gra o tron",
                    Genre = "Fantasy",
                    Description = "Pierwszy tom sagi 'Pieśni Lodu i Ognia'.",
                    Price = 55.00m,
                    Language = "Polski",
                    Pages = 512,
                    CoverName = "gra_o_tron.jpg",
                    AuthorID = 5
                }
            );
            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.BookID, ba.AuthorID }); // Klucz złożony

            modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany()
            .HasForeignKey("AuthorID");

            modelBuilder.Entity<Customer>()
        .HasOne(c => c.Address)
        .WithOne() // Adres należy do jednego klienta
        .HasForeignKey<Customer>(c => c.AddressID); // Klucz obcy w tabeli Klienci

            modelBuilder.Entity<Address>()
       .HasMany(a => a.Customers)
       .WithOne(c => c.Address)
       .HasForeignKey(c => c.AddressID);
        }

    }
    public class BookstoreContexFactory : IDesignTimeDbContextFactory<BookstoreContex>
    {
        BookstoreContex IDesignTimeDbContextFactory<BookstoreContex>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BookstoreContex>();
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5433;Database=Ksiegarnia;Username=postgres;Password=admin");

            return new BookstoreContex(optionsBuilder.Options);
        }
    }
}
