using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksiegarnia.Entities
{
    [Table("Zamowienia_Ksiazki")]
    public class OrdersBooks
    {
        [Column("ID_Zamowienia")]
        public int OrderID { get; set; }

        [ForeignKey("OrderID")]
        public Orders Orders { get; set; }

        [Column("ID_Ksiazki")]
        public int BookID { get; set; }

        [ForeignKey("BookID")]
        public Book Book { get; set; }

        [Column("ilosc")]
        public int Amount { get; set; } = 1;

        [Column("cena_ksiazki")]
        public decimal BookPrice { get; set; }
    }
}
