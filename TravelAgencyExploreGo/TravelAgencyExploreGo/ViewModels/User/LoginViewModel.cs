using System.ComponentModel.DataAnnotations;
using TravelAgencyExploreGo.Common;

namespace TravelAgencyExploreGo.Web.ViewModels.User
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required! Please fill the empty gap!")]
        [EmailAddress(ErrorMessage = "Enter a valid email address. Please try again!")]
        [RegularExpression(EntityValidation.UserEmailRegex, ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
