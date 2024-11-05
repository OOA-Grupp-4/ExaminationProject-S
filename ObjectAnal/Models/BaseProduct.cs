namespace Business.Models;

public abstract class BaseProduct
{
    public string ProductId { get; set; } = Guid.NewGuid().ToString();
    public string ProductName { get; set; } = null!;
    public string ProductPrice { get; set; } = null!;

}


public class WishlistProduct : BaseProduct
{
    public bool Visible { get; set; } = true;
}