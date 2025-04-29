using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
namespace Ksiegarnia
{
    [Table("Ksiazki")]
    public class Book 
    {
        public int ID {  get; set; }
        [Column("tytul")]
        public string Title { get; set; }
        [Column("gatunek")]
        public string Genre { get; set; }
        [Column("opis")]
        public string Description { get; set; }
        [Column("cena")]
        public decimal Price { get; set; }
        [Column("jezyk")]
        public string Language { get; set; }
        [Column("ilosc_stron")]
        public int Pages { get; set; }
        [Column("nazwa_obrazu")]
        public string CoverName {  get; set; }
        [Column("ID_Autora")]
        public int AuthorID {  get; set; }

        public string CoverPath
        {
            get
            {
                string basePath = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "covers");
                return Path.Combine(basePath, CoverName);
            }
        }
        
        public string PriceWithZl
        {
            get
            {
                return $"{Price.ToString()} zł";
            }
        }


        public Author Author { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }

    }
}
