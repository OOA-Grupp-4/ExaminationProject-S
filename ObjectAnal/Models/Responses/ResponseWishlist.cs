namespace Business.Models.Responses;

public class ResponseWishlist<T> : BaseResponse where T : class
{
    public T? Content { get; set; }
}