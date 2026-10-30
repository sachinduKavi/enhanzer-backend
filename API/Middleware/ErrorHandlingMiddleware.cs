using HttpResponse = Enhanzer.Core.Dtos.Response.HttpResponse;
namespace Enhanzer.API.Middleware;

public class ErrorHandlingMiddleware(RequestDelegate next)
{
  private readonly RequestDelegate _next = next;


  public async Task InvokeAsync(HttpContext context)
  {
    try
    { 
      await _next(context);
    } catch (Exception ex)
    {
      (int statusCode, string message, object? data) = MapException(ex);
      Console.Error.WriteLine($"Error: {message} StatusCode: {statusCode}");
      await context.Response.WriteAsJsonAsync<HttpResponse>(new HttpResponse
      {
        Success = false,
        Message = message,
        Data = null
      });
    }
  }

  private static (int StatusCode, string Message, object? Data) MapException(Exception exception) => exception switch
  {
      KeyNotFoundException => (404, exception.Message, null),
      ArgumentException => (400, exception.Message, null),
      UnauthorizedAccessException => (401, exception.Message, null),
      InvalidOperationException => (400, exception.Message, null),
      _ => (500, "An unexpected error occurred.", null)
  };

}