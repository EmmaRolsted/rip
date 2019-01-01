using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationBiavler.Models
{
    public class Varromide
    {
        [Key]
        [Display(Name = "Bistade")]
        public string Bistade { get; set; }

        [Display(Name = "Dato for optælling")]
        public string Date { get; set; }

        [Display(Name = "Antal varroamider")]
        public int VarromidCount { get; set; }

        [Display(Name = "Observationsvarighed (antal dage bakken har ligget")]
        public int Days { get; set; }

        [Display(Name = "Bemærkninger")]
        public string Text { get; set; }
    }
}
