using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pras.Infrastructure.Identity.Models
{
    public sealed class ApplicationUserLoginInfo
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
        public string DisplayName { get; set; }

        public ApplicationUserLoginInfo(string loginProvider, string providerKey, string displayName)
        {
            LoginProvider = loginProvider;
            ProviderKey = providerKey;
            DisplayName = displayName;
        }
    }
}
