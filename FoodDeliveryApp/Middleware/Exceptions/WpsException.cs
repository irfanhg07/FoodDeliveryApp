using System.Net;

namespace Wps.WebApi.Middlewares.Exceptions
{
    public class WpsException : ApplicationException
    {
        public WpsException(string message, string errorCode, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
            : base(message)
        {
            ErrorCode = errorCode;
            StatusCode = statusCode;
        }


        public string ErrorCode { get; }

        public HttpStatusCode StatusCode { get; }
    }
}
