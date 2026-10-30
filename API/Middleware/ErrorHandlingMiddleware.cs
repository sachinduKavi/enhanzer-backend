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
      context.Response.StatusCode = 500;
      await context.Response.WriteAsync("An unexpected error occurred.");
    }
  }

}