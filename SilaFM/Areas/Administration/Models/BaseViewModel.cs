using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pras.Web.Areas.Administration.Models
{
    public class BaseViewModel
    {
        public Guid Id { get; set; }
        public bool IsNew => Id == Guid.Empty;
    }
}
