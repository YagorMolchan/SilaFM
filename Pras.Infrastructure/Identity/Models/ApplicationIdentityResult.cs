using System.Collections.Generic;

namespace Pras.Infrastructure.Identity.Models
{
    public class ApplicationIdentityResult
    {
        public IEnumerable<ApplicationIdentityError> Errors { get; }

        public bool Succeeded { get; }

        public ApplicationIdentityResult(IEnumerable<ApplicationIdentityError> errors, bool succeeded)
        {
            Succeeded = succeeded;
            Errors = errors;
        }
    }
}
