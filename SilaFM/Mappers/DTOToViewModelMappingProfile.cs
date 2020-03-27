using AutoMapper;
using Pras.BLL.DTO;
using Pras.Web.Areas.Administration.Models;

namespace Pras.Web.Mappers
{
    public class DTOToViewModelMappingProfile : Profile
    {
        public DTOToViewModelMappingProfile()
        {
            CreateMap<AudioDTO, AudioViewModel>();
            CreateMap<InformationDTO, InformationViewModel>();
            CreateMap<PersonDTO, PersonViewModel>();
            CreateMap<SpeakerDTO, SpeakerViewModel>();
            CreateMap<VideoDTO, VideoViewModel>();
            CreateMap<ReviewDTO, ReviewViewModel>();
            CreateMap<SettingsDTO, SettingsViewModel>();

            CreateMap<SettingsDTO, Models.SettingsViewModel>();
            CreateMap<SpeakerDTO, Models.SpeakerViewModel>();
            CreateMap<SpeakerDTO, Models.FullSpeakerViewModel>();
        }
        public override string ProfileName
        {
            get { return "DTOToDomainMappings"; }
        }
    }
}

