using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Ksiegarnia.Entities
{
    [Table("Klienci")]
    public class Customer
    {
        public int ID { get; set; }
        [Column("imie")]
        public string Name { get; set; }
        [Column("nazwisko")]
        public string Surname { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("haslo")]
        public string Password { get; set; }
        [Column("telefon")]
        public string PhoneNumber { get; set; }

        [Column("ID_Adresu")]
        public int? AddressID { get; set; }

        [ForeignKey("AddressID")]
        public virtual Address Address { get; set; }
    }
}
