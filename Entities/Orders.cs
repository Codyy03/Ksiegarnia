using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksiegarnia.Entities
{
    [Table("Zamowienia")]
    public class Orders
    {
        public int ID { get; set; }
        [Column("data_zamowienia")]
        public DateTime OrderDate { get; set; }
        [Column("kwota")]
        public decimal PirceOrder { get; set; }

        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

    }
}
