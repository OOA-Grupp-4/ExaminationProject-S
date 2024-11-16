namespace Business.Models.Products;

public class CartProduct : BaseProduct
{
    public decimal Weight { get; set; } = 0m;
    public int Amount { get; set; } = 0;
}
