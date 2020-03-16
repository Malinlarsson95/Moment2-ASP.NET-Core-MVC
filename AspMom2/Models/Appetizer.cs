using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspMom2.Models
{
    public class Appetizer
    {
        [Required(ErrorMessage ="Fyll i rättens namn")]
        [Display(Name = "Namn på rätten:")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Välj vilken typ av rätt")]
        [Display(Name = "Vad för typ är rätten:")]
        public string Type { get; set; }

        [Required]
        [Range(50, 2000, ErrorMessage="Måste ligga mellan {1} och {2}")]
        [Display(Name = "Pris:")]
        public int Price { get; set; }
        [Required]
        [Display(Name = "Glutenfri:")]
        public bool Glutenfri { get; set; }
        [Required]
        [Display(Name = "Laktosfri:")]
        public bool Laktosfri { get; set; }

        public Appetizer()
        {
            Glutenfri = false;
            Laktosfri = false;
        }
    }
}
