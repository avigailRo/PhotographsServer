using Microsoft.Extensions.DependencyInjection;
using BuisnessLogic.Interfaces;
using BuisnessLogic.Services;
using DataAccess;

namespace BuisnessLogic
{
    public static class ServiceCollectionExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddScoped<IPhotographService, PhotographService>();
            //services.AddSingleton<IContext, AssignmentsContext>();
            //services.AddAutoMapper(typeof(Mapper));
        }
    }
}