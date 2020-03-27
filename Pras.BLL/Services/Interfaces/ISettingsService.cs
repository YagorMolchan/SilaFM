using Pras.BLL.DTO;

namespace Pras.BLL.Services.Interfaces
{
    public interface ISettingsService
    {
        SettingsDTO Find();
        SettingsDTO Save(SettingsDTO model);
    }
}
