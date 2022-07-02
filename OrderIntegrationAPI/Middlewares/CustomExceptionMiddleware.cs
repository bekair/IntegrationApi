using OrderIntegrationSystem.Common.Errors;
using System.Net;

namespace OrderIntegrationSystem.API.Middlewares
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                var responseModel = new ErrorModel
                {
                    Message = error.Message
                };

                response.StatusCode = error switch
                {
                    IOException or 
                    FileNotFoundException => (int)HttpStatusCode.BadRequest,
                    _ => (int)HttpStatusCode.InternalServerError,
                };

                responseModel.StatusCode = response.StatusCode;
                var result = responseModel.ToString();

                await response.WriteAsync(result);
            }
        }

    }
}
