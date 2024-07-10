using System.ComponentModel.DataAnnotations;

namespace eTickets.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name gerekli bilgidir...")]
        public string FullName { get; set; }

        [Display(Name = "EMail Address")]
        [Required(ErrorMessage = "EMail Adress gerekli bilgidir...")]
        public string EMailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display (Name = "Confirm Password")]
        [Required (ErrorMessage ="Confirm Password gerekli bilgidir...")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Password bilgileri uyumsuz...")]
        public string ConfirmPassword { get; set; }

    }
}
