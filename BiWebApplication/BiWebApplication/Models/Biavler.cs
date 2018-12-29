using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BiWebApplication.Models
{
    public class Biavler
    {
        [Key]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DBF { get; set; }
        public string EmailAddress { get; set; }
        public string Address1 { get; set; }
        public string Adress2 { get; set; }
        public int ZIPCode { get; set; }
        public string City { get; set; }
    }
}
