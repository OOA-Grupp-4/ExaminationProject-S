using Business.Models.Products;
using Business.Models.Responses;

namespace Business.Interfaces;

public interface IWishlistService
{
    public ContentResponse<IEnumerable<WishlistProduct>> GetVisibleProducts(List<WishlistProduct> userWishlist);
}
