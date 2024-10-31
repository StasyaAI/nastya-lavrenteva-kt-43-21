using _1_лабораторная.Interfaces.TeachersInterfaces;

namespace _1_лабораторная.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITeacherService, TeacherService>();

            return services;
        }
    }
}