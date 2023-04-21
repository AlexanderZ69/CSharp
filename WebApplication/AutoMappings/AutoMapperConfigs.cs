using AutoMapper;
using WebApp.MODELS.Data;
using WebApp.MODELS.Request;

namespace WebApplicationN.AutoMappings
{
    public class AutoMapperConfigs : Profile
    {
        public AutoMapperConfigs()
        {
            CreateMap<AddAuthorRequest, Author>();
        }
    }
}
