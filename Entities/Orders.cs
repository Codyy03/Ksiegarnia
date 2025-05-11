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

        private DateTime _orderDate = DateTime.UtcNow;
        [Column("data_zamowienia")]
        public DateTime OrderDate
        {
            get => _orderDate;
            set => _orderDate = value.ToUniversalTime(); // Konwersja na UTC
        }
        [Column("kwota")]
        public decimal PirceOrder { get; set; }

        [Column("ID_Klienta")]
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

        public ICollection<OrdersBooks> OrderBooks { get; set; } = new List<OrdersBooks>();

    }
}
