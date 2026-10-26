using System.ComponentModel.DataAnnotations;
using TravelAgencyExploreGo.Common;

namespace TravelAgencyExploreGo.Web.ViewModels.User
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(EntityValidation.UserFirstNameLengthMax, MinimumLength = EntityValidation.UserFirstNameLengthMin)]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(EntityValidation.UserLastNameLengthMax, MinimumLength = EntityValidation.UserLastNameLengthMin)]
        public string LastName { get; set; } = null!;
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address. Please try again!")]
        [RegularExpression(EntityValidation.UserEmailRegex, ErrorMessage = "Enter a valid email address, e.g. name@example.com.")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [StringLength(EntityValidation.UserPasswordLengthMax, MinimumLength = EntityValidation.UserPasswordLengthMin,
            ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "Confirm your password!")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords are not the same! Please try again!")]
        public string ConfirmPassword { get; set; } = null!;
        [Required(ErrorMessage = "Plese enter phone number to communicate with.")]
        [StringLength(EntityValidation.UserPhoneNumberLengthMax, MinimumLength = EntityValidation.UserPhoneNumberLengthMin,
            ErrorMessage = "Phone number must be between 10 and 20(for international numbers) characters.")]
        public string PhoneNumber { get; set; } = null!;
    }
}
