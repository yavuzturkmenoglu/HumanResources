using AutoMapper;
using HumanResources.Data.Dtos;
using HumanResources.Data.Entities;

namespace HumanResources.Business.Utility.MapperWrapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserPreviewDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<Inventory, InventoryDto>().ReverseMap();
            CreateMap<Education, EducationDto>().ReverseMap();
        }
    }
}
