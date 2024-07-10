using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace eTickets.Models
{
    // 39
    public class ApplicationUser : IdentityUser
    {
        [Display(Name ="Full Name")]
        public string FullName { get; set; }
    }
}
