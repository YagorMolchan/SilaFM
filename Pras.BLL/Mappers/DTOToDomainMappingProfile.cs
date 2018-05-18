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
        }
        public override string ProfileName
        {
            get { return "DTOToDomainMappings"; }
        }
    }
}

