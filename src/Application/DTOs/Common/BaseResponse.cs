namespace Application.DTOs.Common;
public class BaseResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }
    public List<string> Errors { get; set; } = new();
    public int StatusCode { get; set; }

    public static BaseResponse<T> SuccessResponse(T data, string message = "Operation completed successfully.")
    {
        return new BaseResponse<T>
        {
            Success = true,
            Message = message,
            Data = data,
            StatusCode = 200
        };
    }

    public static BaseResponse<T> FailureResponse(string message, List<string>? errors = null, int statusCode = 400)
    {
        return new BaseResponse<T>
        {
            Success = false,
            Message = message,
            Errors = errors ?? new List<string>(),
            StatusCode = statusCode
        };
    }

    public static BaseResponse<T> NotFoundResponse(string entityName)
    {
        return new BaseResponse<T>
        {
            Success = false,
            Message = $"{entityName} was not found.",
            StatusCode = 404
        };
    }

    public static BaseResponse<T> ValidationErrorResponse(List<string> errors)
    {
        return new BaseResponse<T>
        {
            Success = false,
            Message = "Validation failed.",
            Errors = errors,
            StatusCode = 422
        };
    }
}