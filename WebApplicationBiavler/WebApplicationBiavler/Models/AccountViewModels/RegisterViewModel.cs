using System.ComponentModel.DataAnnotations;

namespace WebApplicationBiavler.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Fornavn")]
        public string Name { get; set; }
        [Display(Name = "Efternavn")]
        public string LastName { get; set; }
        [Display(Name = "Dansk Biavler Forening")]
        public string DBF { get; set; }
        [Display(Name = "Adresse linie 1")]
        public string Address1 { get; set; }
        [Display(Name = "Adresse linie 2")]
        public string Adress2 { get; set; }
        [Display(Name = "Postnummer")]
        public int ZIPCode { get; set; }
        [Display(Name = "By")]
        public string City { get; set; }

    }
}
