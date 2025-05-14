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
        public DbSet<OrdersBooks> OrdersBooks { get; set; }
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
                    ID = 6,
                    Title = "Lalka",
                    Genre = "Powieść",
                    Description = "Klasyczna powieść Bolesława Prusa.",
                    Price = 49.99m,
                    Language = "Polski",
                    Pages = 640,
                    CoverName = "lalka.jpg",
                    AuthorID = 41
                },
                new Book
                {
                    ID = 7,
                    Title = "1984",
                    Genre = "Dystopia",
                    Description = "Powieść George'a Orwella o totalitarnym państwie.",
                    Price = 39.99m,
                    Language = "Angielski",
                    Pages = 328,
                    CoverName = "1984.jpg",
                    AuthorID = 42
                },
                new Book
                {
                    ID = 8,
                    Title = "Mistrz i Małgorzata",
                    Genre = "Powieść",
                    Description = "Rosyjska powieść Michaiła Bułhakowa.",
                    Price = 55.00m,
                    Language = "Rosyjski",
                    Pages = 384,
                    CoverName = "mistrz_malgorzata.jpg",
                    AuthorID = 43
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

         modelBuilder.Entity<OrdersBooks>()
         .HasKey(ob => new { ob.BookID, ob.OrderID }); // klucz złożony

         modelBuilder.Entity<OrdersBooks>()
         .HasOne(ob => ob.Book)
         .WithMany(b => b.OrderBooks)
         .HasForeignKey(ob => ob.BookID)
         .OnDelete(DeleteBehavior.Cascade); // usuwaj powiązanie jeśli książka znika

         modelBuilder.Entity<OrdersBooks>()
         .HasOne(ob => ob.Orders)
         .WithMany(o => o.OrderBooks)
         .HasForeignKey(ob => ob.OrderID)
         .OnDelete(DeleteBehavior.Cascade); // usuwaj powiązanie jeśli zamówienie znika
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
