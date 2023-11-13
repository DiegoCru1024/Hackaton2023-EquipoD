using System.Text.Json;

namespace WebApi.Contracts;

public class ErrorResponse
{
    public string? StatusCode { get; set; }
    public string Message { get; set; }
    public IDictionary<string, string[]>? Errors { get; set; }
    public ErrorResponse(string message)
    {
        this.Message = message;
    }
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}