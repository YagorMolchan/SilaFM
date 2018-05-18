using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pras.DAL.Entities;
using Pras.Infrastructure.Identity.Enums;
using Pras.Infrastructure.Identity.Extensions;
using Pras.Infrastructure.Identity.Interfaces;
using Pras.Infrastructure.Identity.Models;

namespace Pras.Infrastructure.Identity
{
    public class AppUserManager : IAppUserManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private bool _disposed;
        public AppUserManager(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual async Task<bool> CheckPasswordAsync(AppUser user, string password)
        {
            var applicationUser = user.ToApplicationUser();
            var flag = await _userManager.CheckPasswordAsync(applicationUser, password).ConfigureAwait(false);
            user.CopyApplicationIdentityUserProperties(applicationUser);
            return flag;
        }

        public virtual async Task<AppUser> FindByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email).ConfigureAwait(false);
            return user.ToAppUser();
        }

        public virtual async Task<AppUser> FindByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId).ConfigureAwait(false);
            return user.ToAppUser();
        }

        public virtual async Task<AppUser> FindByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName).ConfigureAwait(false);
            return user.ToAppUser();
        }

        public virtual async Task<bool> IsLockedOutAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return await _userManager.IsLockedOutAsync(user).ConfigureAwait(false);
        }

        public virtual async Task<SignInStatus> PasswordSignInAsync(string email, string password, bool isPersistent, bool shouldLockout)
        {
            var user = await _userManager.FindByNameAsync(email).ConfigureAwait(false);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(email).ConfigureAwait(false);
                if (user == null)
                {
                    return SignInStatus.Failure;
                }
            }
            if (await IsLockedOutAsync(user.Id).ConfigureAwait(false))
            {
                return SignInStatus.LockedOut;
            }
            if (await _userManager.CheckPasswordAsync(user, password).ConfigureAwait(false))
            {
                await _signInManager.SignInAsync(user, isPersistent).ConfigureAwait(false);
                return SignInStatus.Success;
            }
            if (shouldLockout)
            {
                // If lockout is requested, increment access failed count which might lock out the user
                await _userManager.AccessFailedAsync(user).ConfigureAwait(false);
                if (await IsLockedOutAsync(user.Id).ConfigureAwait(false))
                {
                    return SignInStatus.LockedOut;
                }
            }
            return SignInStatus.Failure;
        }

        public virtual async Task<bool> IsEmailConfirmedAsync(AppUser appUser)
        {
            var user = await _userManager.FindByIdAsync(appUser.Id);
            return await _userManager.IsEmailConfirmedAsync(user);
        }

        public virtual async Task<string> GeneratePasswordResetTokenAsync(AppUser appUser)
        {
            var user = await _userManager.FindByIdAsync(appUser.Id);
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public virtual async Task<ApplicationIdentityResult> ResetPasswordAsync(AppUser appUser, string code, string password)
        {
            var user = await _userManager.FindByIdAsync(appUser.Id);
            var result = await _userManager.ResetPasswordAsync(user, code, password).ConfigureAwait(false);
            return result.ToApplicationIdentityResult();
        }

        public virtual async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }


        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
