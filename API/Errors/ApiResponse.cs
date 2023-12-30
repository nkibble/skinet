
using SQLitePCL;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GenerateDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GenerateDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "You've made a bad request. Please review your request parameters.",
                401 => "You're not authorised. Please speak to your Account Manager.",
                404 => "The requested resource was not found. Please check you've requested the correct resource.",
                500 => "Server errors encountered. Please speak to your Account Manager.",
                  _ => null
            };
        }
    }
}