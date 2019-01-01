using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebApplicationBiavler.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {

        public string Name { get; set; }

        public string LastName { get; set; }
  
        public string DBF { get; set; }

        public string Address1 { get; set; }

        public string Adress2 { get; set; }
  
        public int ZIPCode { get; set; }

        public string City { get; set; }
    }
}
