using Business.Models.Products;

namespace Business.Models.Responses;

public class CartResponse : ContentResponse<CartProduct>
{
    public decimal? WeightTotal { get; set; }
}
