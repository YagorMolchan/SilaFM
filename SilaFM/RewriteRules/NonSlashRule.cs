using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Rewrite;

namespace Pras.Web.RewriteRules
{
    public class NonSlashRule : IRule
    {
        public void ApplyRule(RewriteContext context)
        {
            var req = context.HttpContext.Request;
            var url = req.GetDisplayUrl();
            var path = req.Path;
            if (path.Value != "/" && url.EndsWith('/'))
            {
                var newUrl = url.Substring(0, url.Length - 1);
                context.HttpContext.Response.Redirect(newUrl, true);
                context.Result = RuleResult.EndResponse;
            }
        }
    }
}
