using Business.Interfaces;
using Business.Models.Products;
using Business.Models.Responses;
namespace Business.Services;


public class WishlistService : IWishlistService
{
    private List<WishlistProduct> _returnList;

    public WishlistService()
    {
        _returnList = [];
    }

    public ResponseWishlist<IEnumerable<WishlistProduct>> GetVisibleProducts(List<WishlistProduct> userWishlist)
    {
        try
        {
            foreach (var product in userWishlist)
            {
                if (product.Visible == true)
                {
                    _returnList.Add(product);
                }
            }
            return new ResponseWishlist<IEnumerable<WishlistProduct>>
                { 
                Success = true,
                Content = _returnList 
                };
        }
        catch (Exception ex)
        {
            return new ResponseWishlist<IEnumerable<WishlistProduct>>
            {
                Message = ex.Message,
                Success = false,
            };
        }
    }
}
