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
        public int ID { get; set; }
        public int OrderID { get; set; }

        [ForeignKey("OrderID")]
        public Orders Orders { get; set; }

        public int BookID { get; set; }
        [ForeignKey("BookID")]
        public Book Book { get; set; }

        public int Amount { get; set; } = 1; // domyślna warotść to 1
        public decimal BookPrice { get; set; }


    }
}
