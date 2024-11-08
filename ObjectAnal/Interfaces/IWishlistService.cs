using Business.Models.Products;

namespace Business.Interfaces;

public interface IWishlistService
{
    public List<WishlistProduct> VisibilityCheck(List<WishlistProduct> userWishlist);
}
