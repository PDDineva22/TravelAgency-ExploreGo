using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using TravelAgencyExploreGo.Common;

namespace TravelAgencyExploreGo.Data.Models
{
    public class User : IdentityUser<Guid>
    {
        [Required]
        [StringLength(EntityValidation.userFirstNameLengthMax, MinimumLength = EntityValidation.userFirstNameLengthMin)]
        public string FirstName { get; set; } = null!;
        [Required]
        [StringLength(EntityValidation.userLastNameLengthMax, MinimumLength = EntityValidation.userLastNameLengthMin)]
        public string LastName { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
    }
}
