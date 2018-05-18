using AutoMapper;
using Pras.BLL.DTO;
using Pras.DAL.Entities;

namespace Pras.BLL.Mappers
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Audio, AudioDTO>();
            CreateMap<Information, InformationDTO>();
            CreateMap<Person, PersonDTO>();
            CreateMap<Speaker, SpeakerDTO>();
            CreateMap<Video, VideoDTO>();
        }
        public override string ProfileName
        {
            get { return "DomainToDTOMappings"; }
        }
    }
}
