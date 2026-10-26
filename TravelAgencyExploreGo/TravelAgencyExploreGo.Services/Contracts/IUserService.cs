using Microsoft.AspNetCore.Identity;
using TravelAgencyExploreGo.Models.DTOs.User;

namespace TravelAgencyExploreGo.Services.Contracts
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterAsync(RegisterDto model);
        Task<SignInResult> LoginAsync(LoginDto model);
        ContactDto? GetUserContact(Guid userId);
        Task LogoutAsync();
    }
}
