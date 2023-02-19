using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MyResumeSite.Models
{
    public class AdminInfo : IdentityUser
    {
        [Required(ErrorMessage = "* Please enter your name!")]
        [MaxLength(50)]
        public string FullName { get; set; }
        [MaxLength(500)]
        public string Address { get; set; }
        [MaxLength(100)]
        public string Image { get; set; }
        [Required(ErrorMessage = "* Please enter you PhoneNumber!")]
        public string PhoneNum { get; set; }
    }
}
