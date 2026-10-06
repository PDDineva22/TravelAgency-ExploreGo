using System.ComponentModel.DataAnnotations;
using TravelAgencyExploreGo.Common;

namespace TravelAgencyExploreGo.ViewModels.User
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(EntityValidation.userFirstNameLengthMax, MinimumLength = EntityValidation.userFirstNameLengthMin)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(EntityValidation.userLastNameLengthMax, MinimumLength = EntityValidation.userLastNameLengthMin)]
        public string LastName { get; set; } = null!;
        [Required]
        [EmailAddress]
        [RegularExpression(EntityValidation.userEmailRegex, ErrorMessage = "Enter valid email. Please try again!")]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;
    }
}
