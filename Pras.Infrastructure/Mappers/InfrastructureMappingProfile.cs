using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Pras.Infrastructure.Identity.Models;

namespace Pras.Infrastructure.Mappers
{
    public class InfrastructureMappingProfile : Profile
    {
        public InfrastructureMappingProfile()
        {
            CreateMap<IdentityError, ApplicationIdentityError>();
        }
        public override string ProfileName
        {
            get { return "InfrastructureMappings"; }
        }
    }
}
