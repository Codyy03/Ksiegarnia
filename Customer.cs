using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Ksiegarnia
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
        [Column("numer_telefonu")]
        public string PhoneNumber { get; set; }

        public int? AddressID { get; set; }
        [ForeignKey("AddressID")]
        public Address Address {  get; set; }

    }
}
