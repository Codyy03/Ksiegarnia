using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksiegarnia.Entities
{
    [Table("Autorzy_Ksiazki")]
    public class BookAuthor
    {
        [Column("ID")]
        public int ID { get; set; }

        [Column("ID_Ksiazki")]
        public int BookID { get; set; }
        [ForeignKey("BookID")]
        public Book Book { get; set; }
        [Column("ID_Autora")]
        public int AuthorID { get; set; }
        [ForeignKey("AuthorID")]
        public Author Author { get; set; }





    }


}
