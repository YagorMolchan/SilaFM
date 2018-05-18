using System;
using System.Configuration;
using System.Web.Configuration;

namespace Pras.Shared.Helpers
{
    public class ConfigurationHelper
    {
        public static bool IsRelease
        {
            get
            {
                string key = WebConfigurationManager.AppSettings["IsRelease"];
                if (!string.IsNullOrEmpty(key))
                    return Convert.ToBoolean(key);
                throw new ConfigurationErrorsException("Unable to find element IsRelease in Web.config ");
            }
        }

        public static bool IsClient
        {
            get
            {
                string key = WebConfigurationManager.AppSettings["IsClient"];
                if (!string.IsNullOrEmpty(key))
                    return Convert.ToBoolean(key);
                throw new ConfigurationErrorsException("Unable to find element IsClient in Web.config ");
            }
        }

        public static string CDN
        {
            get
            {
                string key = WebConfigurationManager.AppSettings["CDN"];
                if (!string.IsNullOrEmpty(key))
                    return key;
                throw new ConfigurationErrorsException("Unable to find element CDN in Web.config ");
            }
        }
    }
}
