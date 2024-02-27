using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Util
{
    public static class ApiResponse
    {

        public static IActionResult SuccessResponse(string message, object responseObject, int statusCode = 200)
        {
            var response = new Dictionary<string, object>
    {
        { "message", message },
        { "data", responseObject }
    };
            return new ObjectResult(response)
            {
                StatusCode = statusCode
            };
        }

        public static IActionResult ErrorResponse(string errorMessage, int statusCode)
        {
            var errorResponse = new Dictionary<string, object>
    {
        { "error", errorMessage }
    };
            return new ObjectResult(errorResponse)
            {
                StatusCode = statusCode
            };
        }


    }
}
