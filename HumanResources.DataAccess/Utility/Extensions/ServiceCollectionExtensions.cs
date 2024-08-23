using HumanResources.DataAccess.EntityFramework;
using HumanResources.DataAccess.Repositories.Abstract;
using HumanResources.DataAccess.Repositories.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HumanResources.DataAccess.Utility.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccessServices(this IServiceCollection services, string sqlConnectionString)
        {
            services.AddDbContext<Context>(options => { options.UseSqlServer(sqlConnectionString); });
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IEducationRepository, EducationRepository>();
        }
    }
}
