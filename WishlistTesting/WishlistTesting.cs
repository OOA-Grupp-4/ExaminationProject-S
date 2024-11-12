using Business.Interfaces;
using Business.Models.Products;
using Business.Services;
using Moq;

namespace WishlistTesting;

public class WishlistTesting
{
    private readonly IWishlistService _wishlistService;
    private List<WishlistProduct> _currentProductsOnSite;
    
    public WishlistTesting()
    {
        _wishlistService = new WishlistService();
        _currentProductsOnSite = [];
    }

    private WishlistProduct CreateTestProduct(string id, string name, string price, bool visible)
    {
        return new WishlistProduct
        {
            ProductId = id,
            ProductName = name,
            ProductPrice = price,
            Visible = visible
        };
    }

    [Fact]
    public void GetVisibleProducts_ShouldReturnOnlyVisibleApple()
    {
        //Arrange
        _currentProductsOnSite = new List<WishlistProduct>
        {
            CreateTestProduct("3e36a463-4a5b-42c5-a4d4-7baf9f4e0e37", "Apple", "20", true),
            CreateTestProduct("29049a13-f610-4d86-b68f-42cc92de79a4", "Pear", "10", false)
        };

        //Act
        var result = _wishlistService.GetVisibleProducts(_currentProductsOnSite);

        //Assert
        Assert.True(result.Success);
        Assert.Single(result.Content);
        Assert.Contains(result.Content, p => p.ProductName == "Apple");
    }

    [Fact]
    public void GetVisibleProducts_ShouldReturnAllProducts()
    {
        //Arrange 
        _currentProductsOnSite = new List<WishlistProduct>
        {
            CreateTestProduct("3e36a463-4a5b-42c5-a4d4-7baf9f4e0e37", "Apple", "20", true),
            CreateTestProduct("29049a13-f610-4d86-b68f-42cc92de79a4", "Pear", "10", true)
        };

        //Act
        var result = _wishlistService.GetVisibleProducts(_currentProductsOnSite);

        //Assert
        Assert.True(result.Success);
        Assert.True(result.Content.Count() == 2);
    }

    [Fact]
    public void GetVisibleProducts_SendEmptyList_ShouldReturnEmptyListAndTrue()
    {
        //Act
        var result = _wishlistService.GetVisibleProducts(_currentProductsOnSite);

        //Assert
        Assert.True(result.Success);
        Assert.Empty(result.Content);
    }
}