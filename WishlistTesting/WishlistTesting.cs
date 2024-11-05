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
    [Fact]
    public void AdminChangeVisibility_ShouldReturnSmallerList()
    {
        //Arrange



        //Act



        //Assert



    }
    [Fact]
    public void AdminChangeVisibility_ShouldReturnALongerList()
    {

    }
}
