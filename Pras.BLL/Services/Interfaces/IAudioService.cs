using System;
using System.Collections.Generic;
using Pras.BLL.DTO;

namespace Pras.BLL.Services.Interfaces
{
    public interface IAudioService
    {
        List<AudioDTO> Find();
        AudioDTO Find(Guid id);
        AudioDTO Save(AudioDTO model);
        void Delete(Guid id);

        List<string> GetLastAudio(int count);
    }
}
