using AutoMapper;
using Pras.BLL.DTO;
using Pras.DAL.Entities;

namespace Pras.BLL.Mappers
{
    public class DTOToDomainMappingProfile : Profile
    {
        public DTOToDomainMappingProfile()
        {
            CreateMap<AudioDTO, Audio>();
            CreateMap<InformationDTO, Information>();
            CreateMap<PersonDTO, Person>();
            CreateMap<SpeakerDTO, Speaker>();
            CreateMap<VideoDTO, Video>();
            CreateMap<ReviewDTO, Review>();
            CreateMap<SettingsDTO, Settings>();
            CreateMap<ServiceDTO, Service>();
            CreateMap<CharacterDTO, Character>();
        }
        public override string ProfileName
        {
            get { return "DTOToDomainMappings"; }
        }
    }
}

