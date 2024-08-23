using FluentValidation;
using HumanResources.Business.Abstract;
using HumanResources.Business.Implementation;
using HumanResources.Business.Utility.MapperWrapper;
using HumanResources.Business.Utility.Validation;
using HumanResources.Data.Dtos;
using Microsoft.Extensions.DependencyInjection;

namespace HumanResources.Business.Utility.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IMapper, Mapper>();
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<IValidator<UserDto>, UserDtoValidator>();
            services.AddScoped<IValidator<EducationDto>, EducationDtoValidator>();
            services.AddScoped<IValidator<InventoryDto>, InventoryDtoValidator>();
        }
    }
}
