using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pras.BLL.DTO;

namespace Pras.BLL.Services.Interfaces
{
    public interface IServiceService
    {
        ServiceDTO Save(ServiceDTO model);

        List<ServiceDTO> Find();

        ServiceDTO Find(Guid id);

        void Delete(Guid id);
    }
}
