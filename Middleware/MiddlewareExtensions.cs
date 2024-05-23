using aspnetcoremvcapp.Repository;

namespace aspnetcoremvcapp.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IServiceCollection AddAppMiddleware(this IServiceCollection services)
        {
            services.AddTransient<RequestLoggerMiddleware>();
            // Add more custom middlewares

            return services;
        }

        public static IApplicationBuilder UseRequestLoggerMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestLoggerMiddleware>();
        }
    }
}
