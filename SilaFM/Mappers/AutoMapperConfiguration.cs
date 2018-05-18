using AutoMapper;
using Pras.BLL.Mappers;
using Pras.Infrastructure.Mappers;

namespace Pras.Web.Mappers
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ViewModelToDTOMappingProfile>();
                x.AddProfile<DTOToViewModelMappingProfile>();
                x.AddProfile<InfrastructureMappingProfile>();
                x.AddProfile<DTOToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDTOMappingProfile>();
            });
        }
    }
}
