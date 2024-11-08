using Business.Interfaces;
using Business.Models.Products;
namespace Business.Services;


public class WishlistService : IWishlistService
{
    private List<WishlistProduct> _returnList;

    public WishlistService()
    {
        _returnList = [];
    }

    public List<WishlistProduct> VisibilityCheck(List<WishlistProduct> userWishlist)
    {
        foreach (var product in userWishlist)
        {
            if (product.Visible == true)
            {
            _returnList.Add(product);
            }
        }
        return _returnList;
    }
}
