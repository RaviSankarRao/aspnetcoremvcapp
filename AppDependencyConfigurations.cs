using aspnetcoremvcapp.Data;
using aspnetcoremvcapp.Repository;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;
using Microsoft.EntityFrameworkCore;

namespace aspnetcoremvcapp
{
    public static class AppDependencyConfigurations
    {
        // Extension method to register Database context
        public static IServiceCollection ConfigureDatabaseContext(this IServiceCollection services, string connectionString)
        {
            if (connectionString == null)
                throw new InvalidOperationException("Connection string 'MvcMovieContext' not found.");

            services.AddDbContext<MvcMovieContext>(options => options.UseSqlServer(connectionString));
            return services;
        }

        // Extension method to register all dependent services
        public static IServiceCollection ConfigureAppDepenencies(this IServiceCollection services)
        {
            services.AddScoped<IMoviesRepository, MoviesRepository>();

            return services;
        }
    }
}
