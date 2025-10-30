using Application.Interfaces.ForRepositories;
using Application.Interfaces.ForServices;
using Application.Services;
using Infrastructure.Repositories;
using System.Reflection;

namespace Api.Controllers.Extensions
{
    public static class DICollectionExtensions
    {
        public static IServiceCollection AddDICollection(this IServiceCollection services)
        {
            //Add DI to services

            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IStudentService,  StudentService>();
            services.AddScoped<IСompetenciesManagerService, СompetenciesManagerService>();

            //Add DI to repositories

            services.AddScoped<ICourseRepositorie, CourseRepositorie>();
            services.AddScoped<IGroupRepositorie, GroupRepositorie>();
            services.AddScoped<IStudentRepositorie, StudentRepositorie>();

            //Add DI to mapers

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}