using aspnetcoremvcapp.Repository;

namespace aspnetcoremvcapp.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IServiceCollection ConfigureMiddleware(this IServiceCollection services)
        {
            services.AddTransient<RequestLoggerMiddleware>();

            return services;
        }

        public static IApplicationBuilder UseRequestLoggerMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestLoggerMiddleware>();
        }
    }
}
