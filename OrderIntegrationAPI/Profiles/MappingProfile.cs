using AutoMapper;
using OrderIntegrationSystem.Common.Dtos;
using OrderIntegrationSystem.Domain.Models;

namespace OrderIntegrationSystem.API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ArticleDetail, ArticleDetailDto>();
        }
    }
}
