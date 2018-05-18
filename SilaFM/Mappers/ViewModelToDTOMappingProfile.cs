using AutoMapper;
using Pras.BLL.DTO;
using Pras.Web.Areas.Administration.Models;

namespace Pras.Web.Mappers
{
    public class ViewModelToDTOMappingProfile : Profile
    {
        public ViewModelToDTOMappingProfile()
        {
            CreateMap<AudioViewModel, AudioDTO>();
            CreateMap<InformationViewModel, InformationDTO>();
            CreateMap<PersonViewModel, PersonDTO>();
            CreateMap<SpeakerViewModel, SpeakerDTO>();
            CreateMap<VideoViewModel, VideoDTO>();
        }
        public override string ProfileName
        {
            get { return "DomainToDTOMappings"; }
        }
    }
}
