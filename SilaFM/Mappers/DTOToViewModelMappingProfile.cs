using AutoMapper;
using Pras.BLL.DTO;
using Pras.Web.Areas.Administration.Models;
using Pras.Web.Areas.Administration.Models.CharacterViewModels;

namespace Pras.Web.Mappers
{
    public class DTOToViewModelMappingProfile : Profile
    {
        public DTOToViewModelMappingProfile()
        {
            CreateMap<AudioDTO, AudioViewModel>();
            CreateMap<InformationDTO, InformationViewModel>();
            CreateMap<InformationDTO, ContactsViewModel>();
            CreateMap<PersonDTO, PersonViewModel>();
            CreateMap<SpeakerDTO, SpeakerViewModel>();
            CreateMap<VideoDTO, VideoViewModel>();
            CreateMap<ReviewDTO, ReviewViewModel>();
            CreateMap<SettingsDTO, SettingsViewModel>();

            //Services
            CreateMap<ServiceDTO, ServiceViewModel>();

            //Characters
            CreateMap<CharacterDTO, CharacterViewModel>()
                .ForMember(vm => vm.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(vm => vm.SpeakerName, opt => opt.MapFrom(src => src.Speaker.Name));

            CreateMap<SettingsDTO, Models.SettingsViewModel>();
            CreateMap<SpeakerDTO, Models.SpeakerViewModel>();
            CreateMap<SpeakerDTO, Models.FullSpeakerViewModel>();
            CreateMap<InformationDTO, Models.ContactsViewModel>();
            CreateMap<PersonDTO, Models.PersonViewModel>().ForMember(p => p.SocialsList, opts => opts.Ignore());
        }
        public override string ProfileName
        {
            get { return "DTOToDomainMappings"; }
        }
    }
}

