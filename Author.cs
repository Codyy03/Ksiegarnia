using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksiegarnia
{
    [Table("Autorzy")]
    public class Author
    {
        public int ID { get; set; }
        [Column("imie")]
        public string Name { get; set; }
        [Column("nazwisko")]
        public string Surname {  get; set; }
        [Column("narodowosc")]
        public string Nationality { get; set; }
        [Column("biografia")]
        public string Biography { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
