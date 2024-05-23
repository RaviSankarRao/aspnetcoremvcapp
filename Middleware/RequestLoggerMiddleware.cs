
namespace aspnetcoremvcapp.Middleware
{
    // Middleware activated by MiddlewareFactory
    public class RequestLoggerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var request = context.Request;
            var requestPath = request.Path;

            var logRequestInfor = $"{DateTime.Now} - Incoming request - {requestPath}";
            WriteMessage(logRequestInfor);

            // Call the next delegate/middleware in the pipeline
            await next(context);
        }

        private void WriteMessage(string message)
        {
            // Set a variable to the Documents path.
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the string array to file named "RequestLogs.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "RequestLogs.txt"), true))
            {
                outputFile.WriteLine(message);
            }
        }
    }
}
