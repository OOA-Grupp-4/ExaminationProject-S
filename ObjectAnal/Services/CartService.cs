using Business.Interfaces;
using Business.Models.Products;
using Business.Models.Responses;
using System.Diagnostics;

namespace Business.Services;

public class CartService : ICartService
{
    public CartResponse AddToCart(CartProduct cartProduct)
    {
        throw new NotImplementedException();
    }

    public CartResponse RemoveFromCart(string idToRemove)
    {
        throw new NotImplementedException();
    }

    public CartResponse UpdateAmountInCart(string idOfProduct, int newAmount)
    {
        throw new NotImplementedException();
    }

    public CartResponse WeightTotalInCart(List<CartProduct> cartProducts)
    {
        try
        {
            decimal totalWeight = 0;
            foreach (CartProduct cartProduct in cartProducts) 
            {
                decimal productWeight = (cartProduct.Amount * cartProduct.Weight);
                totalWeight += productWeight;
            }
            return new CartResponse()
            {
                Success = true,
                WeightTotal = totalWeight
            };
        }
        catch (Exception ex)
        {
            return new CartResponse()
            {
                Success = false,
                Message = ex.Message
            };
        }

    }
}
