# Salient features

## References

- ASP.NET official documentation - [Link][ASP_NET_Documentation]

## Repository Pattern

- Using repository patterns to move data connection logic out of Controllers
	- Keeps Controller lean
- Check [Repository folder](Repository) for more details

## App start

- Seed data initialization using Service Provider
	- Look for `SeedData.Initialize` in [Program.cs](Program.cs)

## Dependency Injection

- Extension methods for configuring DI services in [DIConfigurations/AppDependencyConfigurations](DIConfigurations/AppDependencyConfigurations.cs)


## Middleware

- Custom middleware - [RequestLoggerMiddleware](Middleware/RequestLoggerMiddleware.cs)
	- Gets the request path and logs to a file
- Extension methods to expose middlerware through IApplication builder - [MiddlewareExtensions](Middleware/MiddlewareExtensions.cs) 

## MVC Controllers

- Passing data to views using ViewData, ViewBag and TempData 
	- Look for `Passing data to views` region in [HomeController](Controllers/HomeController.cs)

## API Controllers

- API controllers are slightly different - Take a look at [MoviesApiController](Controllers/MoviesApiController.cs)

## Testing

### .http files

- VS .http files helps in API testing
- Check [movies_api.http](Tests/movies_api.http) file for testing Movies API

---

[ASP_NET_Documentation]: https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-8.0

---