namespace StudentAdminPortal.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
	using StudentAdminPortal.Application.Services.Courses;
    using StudentAdminPortal.Application.Services.RegistrationCourses;
    using StudentAdminPortal.Application.Services.Student;
	using StudentAdminPortal.Domain.Entities;
	using StudentAdminPortal.Domain.Interfaces;
    using StudentAdminPortal.Infrastructure.Persistence;
    using StudentAdminPortal.Infrastructure.Persistence.Repositories;
    public static class DependencyInjection
    {

        /// <summary>
        /// Adds the infrastructure services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IStudentsService), typeof(StudentsService));
            services.AddScoped(typeof(ICoursesService), typeof(CoursesService));
            services.AddScoped(typeof(IRegistrationCoursesService), typeof(RegistrationCoursesService));

            return services;
        }

        /// <summary>
        /// Initializes the database.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public static void InitializeDatabase(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.Database.Migrate();
        }
    }
}
