using System;

namespace Pras.Infrastructure.Identity.Models
{
    public class ApplicationUserRole
    {
        public virtual Guid RoleId { get; set; }
        public virtual Guid UserId { get; set; }
    }
}
