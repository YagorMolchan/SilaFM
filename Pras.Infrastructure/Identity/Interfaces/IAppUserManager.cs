using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Pras.DAL.Entities;
using Pras.Infrastructure.Identity.Enums;
using Pras.Infrastructure.Identity.Models;

namespace Pras.Infrastructure.Identity.Interfaces
{
    public interface IAppUserManager : IDisposable
    {
        Task<bool> CheckPasswordAsync(AppUser user, string password);
        Task<AppUser> FindByEmailAsync(string email);
        Task<AppUser> FindByIdAsync(string userId);
        Task<AppUser> FindByNameAsync(string userName);
        Task<bool> IsLockedOutAsync(string userId);
        Task<SignInStatus> PasswordSignInAsync(string email, string password, bool rememberMe, bool lockoutOnFailure);
        Task<bool> IsEmailConfirmedAsync(AppUser user);
        Task<string> GeneratePasswordResetTokenAsync(AppUser user);
        Task<ApplicationIdentityResult> ResetPasswordAsync(AppUser user, string code, string password);
        Task SignOutAsync();
    }
}
