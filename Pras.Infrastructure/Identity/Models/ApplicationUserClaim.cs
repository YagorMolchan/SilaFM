using System;

namespace Pras.Infrastructure.Identity.Models
{
    public class ApplicationUserClaim
    {
        public virtual string ClaimType { get; set; }
        public virtual string ClaimValue { get; set; }
        public virtual int Id { get; set; }
        public virtual Guid UserId { get; set; }
    }
}
