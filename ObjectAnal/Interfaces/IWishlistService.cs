using Business.Models.Products;
using Business.Models.Responses;

namespace Business.Interfaces;

public interface IWishlistService
{
    public ResponseWishlist<IEnumerable<WishlistProduct>> GetVisibleProducts(List<WishlistProduct> userWishlist);
}
