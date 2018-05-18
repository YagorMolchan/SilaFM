using Pras.BLL.DTO;
using Pras.Shared.Enums;

namespace Pras.BLL.Services.Interfaces
{
    public interface IInformationService
    {
        InformationDTO Find(InformationTypes type);
        InformationDTO Save(InformationDTO model);
    }
}
