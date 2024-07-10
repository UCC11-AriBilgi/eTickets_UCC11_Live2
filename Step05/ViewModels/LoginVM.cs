using System.ComponentModel.DataAnnotations;

namespace eTickets.ViewModels
{
    public class LoginVM
    {
        [Display(Name ="EMail Address")]
        [Required(ErrorMessage = "EMail Address is required..")]
        public string EMailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
