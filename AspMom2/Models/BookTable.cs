using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspMom2.Models
{
    public class BookTable
    {
        [Required(ErrorMessage = "Fyll i ditt fullständiga namn")]
        [Display(Name = "För och efternamn:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Fyll i en korrekt email-adress")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Fyll i ett telefon-nummer")]
        [Phone(ErrorMessage ="Fyll i ett riktigt telefon-nummer")]
        [Display(Name = "Telefonnummer:")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Ange ett datum")]
        [Display(Name = "Datum:")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Ange en tid")]
        [DataType(DataType.Time, ErrorMessage = "Ange ett datum")]
        [Display(Name = "Tid:")]
        public DateTime Time { get; set; }

        public BookTable()
        {

        }
    }
}
