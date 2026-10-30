namespace Enhanzer.Core.Dtos.Response;

public class HttpResponse
{
  public bool Success { get; set; }
  public string? Message { get; set; } = null!;
  public object? Data { get; set; }
}