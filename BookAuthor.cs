using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksiegarnia
{
    [Table("Autorzy_Ksiazki")]
    public class BookAuthor
    {
        public int BookID { get; set; }
        [ForeignKey("BookID")]
        public Book Book { get; set; }

        public int AuthorID { get; set; }
        [ForeignKey("AuthorID")]
        public Author Author { get; set; }

        public int Amount { get; set; }
        public decimal BookPirce { get; set; }

      

    }


}
