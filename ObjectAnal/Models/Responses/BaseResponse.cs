namespace Business.Models.Responses;

public class BaseResponse
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public Type? Content {  get; set; }
}
