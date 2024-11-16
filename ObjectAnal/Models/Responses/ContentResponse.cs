namespace Business.Models.Responses;

public class ContentResponse<T> : BaseResponse where T : class
{
    public T? Content { get; set; }
}