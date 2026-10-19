using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyExploreGo.Models.DTOs.User;

namespace TravelAgencyExploreGo.Services.Contracts
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterAsync(RegisterDto model);
        Task<SignInResult> LoginAsync(LoginDto model);

        Task LogoutAsync();
    }
}
