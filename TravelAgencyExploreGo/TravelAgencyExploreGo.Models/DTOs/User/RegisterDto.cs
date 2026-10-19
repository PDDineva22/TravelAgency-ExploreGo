using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyExploreGo.Common;

namespace TravelAgencyExploreGo.Models.DTOs.User
{
    public class RegisterDto
    {
        [Required]
        [StringLength(EntityValidation.UserFirstNameLengthMax, MinimumLength = EntityValidation.UserFirstNameLengthMin)]
        public string FirstName { get; set; } = null!;
        [Required]
        [StringLength(EntityValidation.UserLastNameLengthMax, MinimumLength = EntityValidation.UserLastNameLengthMin)]
        public string LastName { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [StringLength(EntityValidation.UserPasswordLengthMax, MinimumLength = EntityValidation.UserPasswordLengthMin)]
        public string Password { get; set; } = null!;
    }
}
