using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace Pras.Infrastructure.Identity.Models
{
    public class ApplicationExternalLoginInfo
    {
        //public string DefaultUserName { get; set; }

        //public string Email { get; set; }

        //public ClaimsIdentity ExternalIdentity { get; set; }

        //public ApplicationUserLoginInfo Login { get; set; }

        public string LoginProvider { get; set; }
        public ClaimsPrincipal Principal { get; set; }
        public IEnumerable<AuthenticationToken> AuthenticationTokens { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderKey { get; set; }
    }
}
