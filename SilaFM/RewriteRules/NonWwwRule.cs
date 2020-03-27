using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Rewrite;

namespace Pras.Web.RewriteRules
{
    public class NonWwwRule : IRule
    {
        public void ApplyRule(RewriteContext context)
        {
            var req = context.HttpContext.Request;
            var url = req.GetDisplayUrl();
            var host = req.Host.ToString();
            if (host.StartsWith("www."))
            {
                context.HttpContext.Response.Redirect(url.Replace(host, host.Substring(4, host.Length)), true);
                context.Result = RuleResult.EndResponse;
            }
        }
    }
}
