using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using TravelAgencyExploreGo.Common;

namespace TravelAgencyExploreGo.Data.Models.Entities
{
    public class User : IdentityUser<Guid>
    {
        [Required]
        [StringLength(EntityValidation.UserFirstNameLengthMax, MinimumLength = EntityValidation.UserFirstNameLengthMin)]
        public string FirstName { get; set; } = null!;
        [Required]
        [StringLength(EntityValidation.UserLastNameLengthMax, MinimumLength = EntityValidation.UserLastNameLengthMin)]
        public string LastName { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
    }
}
