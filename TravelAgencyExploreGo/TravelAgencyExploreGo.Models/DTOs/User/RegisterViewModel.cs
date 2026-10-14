using System.ComponentModel.DataAnnotations;
using TravelAgencyExploreGo.Common;

namespace TravelAgencyExploreGo.Models.DTOs.User
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(EntityValidation.UserFirstNameLengthMax, MinimumLength = EntityValidation.UserFirstNameLengthMin)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(EntityValidation.UserLastNameLengthMax, MinimumLength = EntityValidation.UserLastNameLengthMin)]
        public string LastName { get; set; } = null!;
        [Required]
        [EmailAddress]
        [RegularExpression(EntityValidation.UserEmailRegex, ErrorMessage = "Enter valid email. Please try again!")]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;
    }
}
