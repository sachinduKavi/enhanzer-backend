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
      await context.Response.WriteAsync("An unexpected error occurred.");
    }
  }

  private static (int StatusCode, string Message, object? Data) MapException(Exception exception) => exception switch
  {
      _ => (500, "An unexpected error occurred.", null)
  };

}