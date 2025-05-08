using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksiegarnia.Entities
{
    [Table("Adres")]
    public class Address
    {
        public int ID { get; set; }

        [Column("miejscowosc")]
        public string City { get; set; }

        [Column("ulica")]
        public string Street { get; set; }

        [Column("numer_mieszkania")]
        public string ApartmentNumber { get; set; }

        [Column("numer_domu")]
        public string HomeNumber { get; set; }

        [StringLength(6)]
        [Required]
        [RegularExpression(@"^\d{2}-\d{3}$", ErrorMessage = "Kod pocztowy powinien mieć format XX-XXX")]
        [Column("kod_pocztowy")]
        public string ZipCode { get; set; }

        [InverseProperty("Address")]
        public virtual ICollection<Customer> Customers { get; set; }

    }
}
