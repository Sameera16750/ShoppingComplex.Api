namespace ShoppingComplex.Application.Models.Response
{
    public class HttpResponse
    {
        public int StatusCode { get; private set; }
        public string? Message { get; private set; }
        public object? Data { get; private set; }

        public HttpResponse(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public HttpResponse(int statusCode, object data)
        {
            StatusCode = statusCode;
            Data = data;
        }
    
        public HttpResponse(int statusCode, string message, object data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }
    }    
}

