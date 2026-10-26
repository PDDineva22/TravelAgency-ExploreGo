using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyExploreGo.Common;

namespace TravelAgencyExploreGo.Models.DTOs.User
{
    public class ContactDto
    {
        [Required]
        [StringLength(EntityValidation.UserFirstNameLengthMax, MinimumLength = EntityValidation.UserFirstNameLengthMin)]
        public string FullName { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [StringLength(EntityValidation.UserPhoneNumberLengthMax, MinimumLength = EntityValidation.UserPhoneNumberLengthMin)]
        public string PhoneNumber { get; set; } = null!;
    }
}
