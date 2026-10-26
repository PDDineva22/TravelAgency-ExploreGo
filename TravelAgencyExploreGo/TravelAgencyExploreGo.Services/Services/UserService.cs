using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyExploreGo.Data.Models.Entities;
using TravelAgencyExploreGo.Models.DTOs.User;
using TravelAgencyExploreGo.Services.Contracts;

namespace TravelAgencyExploreGo.Services.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<IdentityResult> RegisterAsync(RegisterDto model)
        {
            User user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            return await userManager.CreateAsync(user, model.Password);
        }
        public async Task<SignInResult> LoginAsync(LoginDto model)
        {
            string email = model.Email;
            string password = model.Password;

            SignInResult result = await signInManager.PasswordSignInAsync(
                email,
                password,
                false,
                true);

            return result;
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }
        /// <summary>
        /// Gets the contact information of a specific user
        /// Returns their contacts,
        /// which are displayed when the user makes a booking
        /// </summary>
        public ContactDto? GetUserContact(Guid userId)
        {
            User? user = userManager.Users
                .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return null;
            }
            ContactDto contact = new ContactDto();

            contact.FullName = $"{user.FirstName} {user.LastName}";
            if(user.Email != null)
            {
                contact.Email = user.Email;
            }
            else
            {
                contact.Email = string.Empty;
            }
            if (user.PhoneNumber != null)
            {
                contact.PhoneNumber = user.PhoneNumber;
            }
            else
            {
                contact.PhoneNumber = string.Empty;
            }

            return contact; 
        }
    }
}
