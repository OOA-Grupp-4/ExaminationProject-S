using Business.Models.Products;
using Business.Models.Responses;

namespace Business.Interfaces;

public interface ICartService
{
    public CartResponse AddToCart(CartProduct cartProduct);
    public CartResponse RemoveFromCart(string idToRemove);
    public CartResponse UpdateAmountInCart(string idOfProduct, int newAmount);
    public CartResponse WeightTotalInCart(List<CartProduct> cartProducts);
}
