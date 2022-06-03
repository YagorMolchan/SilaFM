using AutoMapper;
using Pras.BLL.DTO;
using Pras.Web.Areas.Administration.Models;
using Pras.Web.Areas.Administration.Models.CharacterViewModels;

namespace Pras.Web.Mappers
{
    public class ViewModelToDTOMappingProfile : Profile
    {
        public ViewModelToDTOMappingProfile()
        {
            CreateMap<AudioViewModel, AudioDTO>();
            CreateMap<InformationViewModel, InformationDTO>();
            CreateMap<ContactsViewModel, InformationDTO>();
            CreateMap<PersonViewModel, PersonDTO>();
            CreateMap<SpeakerViewModel, SpeakerDTO>();
            CreateMap<VideoViewModel, VideoDTO>();
            CreateMap<ReviewViewModel, ReviewDTO>();
            CreateMap<SettingsViewModel, SettingsDTO>();
            CreateMap<ServiceViewModel, ServiceDTO>();
            CreateMap<CharacterEditViewModel, CharacterDTO>()
                .ForMember(dto => dto.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dto => dto.ImagePath, opt => opt.MapFrom(src => src.ImagePath));
        }
        public override string ProfileName
        {
            get { return "DomainToDTOMappings"; }
        }
    }
}
