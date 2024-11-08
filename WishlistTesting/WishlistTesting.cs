using Business.Interfaces;
using Business.Models.Products;
using Business.Services;

namespace WishlistTesting;

public class WishlistTesting
{
    /*
    First test is to make sure that if the admin hides a product from the site, it should not show up in peoples wishlist.
    -
    Need a product with a "visible" property that is a bool that the admin will change.
    Need a list of products. 
    Need a list of things inside a wishlist.

    - Methods;  (Focus on single responsibility)
    CheckVisibility(UserWishlist) return ShowList

    - Models;
    Product + WishlistProduct
    Response + WishlistResponse


     */

    private readonly IWishlistService _wishlistService;
    public WishlistTesting()
    {
        _wishlistService = new WishlistService();
    }

    private List<WishlistProduct> ValidWishlistProducts()
    {
        return new List<WishlistProduct>
        {
        new WishlistProduct { ProductId = "1", ProductName = "Tomato", ProductPrice = "10", Visible = true },
        new WishlistProduct { ProductId = "2", ProductName = "Banana", ProductPrice = "15", Visible = true },
        new WishlistProduct { ProductId = "3", ProductName = "Apple", ProductPrice = "20", Visible = true },
        new WishlistProduct { ProductId = "4", ProductName = "Apple", ProductPrice = "20", Visible = false }
        };
    }

    //Send list to checker which returns a smaller list.
    [Fact]
    public void VisibilityCheck_ShouldReturnSmallerList()
    {
        //Arrange
        var _validWishlistProducts = ValidWishlistProducts();

        //Act
        var _testingList = _wishlistService.VisibilityCheck(_validWishlistProducts);


        //Assert
        Assert.True(_validWishlistProducts.Count() > _testingList.Count());


    }
    [Fact]
    public void VisibilityCheck_ShouldReturnALongerList()
    {

    }
}
