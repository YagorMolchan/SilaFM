using System;
using System.Collections.Generic;
using Pras.BLL.DTO;
using Pras.Shared.Enums;

namespace Pras.BLL.Services.Interfaces
{
    public interface ISpeakersService
    {
        List<SpeakerDTO> Find();
        SpeakerDTO Find(Guid id);
        SpeakerDTO Save(SpeakerDTO model);
        void Delete(Guid id);
        
        List<string> GetLastSpeakersNames(int count);
        List<SpeakerDTO> GetLastSpeakers(int count);
        List<SpeakerDTO> Find(SpeakerTypes type);
        List<SpeakerDTO> Find(SpeakerCountries country);
        List<SpeakerDTO> Find(SpeakerTypes type, SpeakerCountries country);
        List<SpeakerDTO> Find(SpeakerCountries country, params SpeakerTypes[] types);
        List<SpeakerDTO> FindVip();
        SpeakerDTO Find(string url);
    }
}
