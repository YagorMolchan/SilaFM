using System;
using System.Collections.Generic;
using Pras.BLL.DTO;

namespace Pras.BLL.Services.Interfaces
{
    public interface ISpeakersService
    {
        List<SpeakerDTO> Find();
        SpeakerDTO Find(Guid id);
        SpeakerDTO Save(SpeakerDTO model);
        void Delete(Guid id);
    }
}
