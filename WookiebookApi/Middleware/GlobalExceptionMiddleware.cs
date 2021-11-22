
using Newtonsoft.Json;
using System.Net;

namespace WookieBooksApi.Middleware
{
    public class GlobalExceptionMiddleware
    {
        public RequestDelegate requestDelegate;
        public ILogger _logger;
        public GlobalExceptionMiddleware(RequestDelegate requestDelegate,ILogger logger)
        {
            this.requestDelegate = requestDelegate;
            this._logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await requestDelegate(context);
            }
            
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (ex)
                {
                    
                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case FileNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                //logging error information
                _logger.LogError(ex.Message);
                var result = JsonConvert.SerializeObject(new { message = ex?.Message });
                await response.WriteAsync(result);
            }
        

        }
        

    }
}
