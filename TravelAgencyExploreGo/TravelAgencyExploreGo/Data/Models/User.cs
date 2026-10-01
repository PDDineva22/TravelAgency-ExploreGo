using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using TravelAgencyExploreGo.Common;

namespace TravelAgencyExploreGo.Data.Models
{
    public class User : IdentityUser<Guid>
    {
        [Required]
        [StringLength(EntityValidation.userFirstNameLenghtMax, MinimumLength = EntityValidation.userFirstNameLenghtMin)]
        public string FirstName { get; set; } = null!;
        [Required]
        [StringLength(EntityValidation.userLastNameLenghtMax, MinimumLength = EntityValidation.userLastNameLenghtMin)]
        public string LastName { get; set; } = null!;
    }
}
