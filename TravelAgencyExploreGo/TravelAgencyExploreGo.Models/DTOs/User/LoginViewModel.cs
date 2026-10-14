using System.ComponentModel.DataAnnotations;
using TravelAgencyExploreGo.Common;

namespace TravelAgencyExploreGo.Models.DTOs.User
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [RegularExpression(EntityValidation.UserEmailRegex, ErrorMessage = "Enter valid email. Please try again!")]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
