using Business.Interfaces;
using Business.Models.Products;
using Business.Models.Responses;
using Moq;

namespace WishlistTesting;

public class MockPackageTesting
{
    private readonly Mock<ICartService> _mockCartService;
    private List<CartProduct> _testCartOfProducts;

    public MockPackageTesting()
    {
        _mockCartService = new Mock<ICartService>();
        _testCartOfProducts = [];
    }

    private CartProduct CreateCartProduct(string id, string name, string price, decimal weight, int amount)
    {
        return new CartProduct
        {
            ProductId = id,
            ProductName = name,
            ProductPrice = price,
            Weight = weight,
            Amount = amount
        };
    }


    [Fact]
    public void AddingProduct_ShouldUpdateWeight()
    {
        //Arrange
        var testProduct = CreateCartProduct("99d1e35d-32da-42d6-8598-e7d68d8b1083", "Tomat", "10", 10m, 1);

        _mockCartService
            .Setup(s => s.AddToCart(It.IsAny<CartProduct>()))
            .Returns(new CartResponse { Success = true, Message = "Product added successfully." });

        _testCartOfProducts.Add(testProduct);

        _mockCartService
            .Setup(s => s.WeightTotalInCart(It.IsAny<List<CartProduct>>()))
            .Returns(new CartResponse { Success = true, Content = new CartProduct { Weight = testProduct.Weight * testProduct.Amount } });

        //Act
        var resultAdding = _mockCartService.Object.AddToCart(testProduct);
        var resultWeight = _mockCartService.Object.WeightTotalInCart(_testCartOfProducts);

        //Assert
        Assert.True(resultAdding.Success);
        Assert.Equal(testProduct.Weight, resultWeight.Content.Weight);
    }

    [Fact]
    public void ChangingProductAmount_ShouldUpdateWeight()
    {
        //Arrange
        var testProduct = CreateCartProduct("99d1e35d-32da-42d6-8598-e7d68d8b1083", "Tomat", "10", 10m, 1);
        _testCartOfProducts.Add(testProduct);

        _mockCartService
            .Setup(s => s.UpdateAmountInCart(testProduct.ProductId, 3))
            .Returns(new CartResponse { Success = true });

        _mockCartService
            .Setup(s => s.WeightTotalInCart(It.IsAny<List<CartProduct>>()))
            .Returns(new CartResponse { Success = true, Content = new CartProduct { Weight = testProduct.Weight * 3 }, });

        //Act
        var resultUpdate = _mockCartService.Object.UpdateAmountInCart(testProduct.ProductId, 3);
        var resultWeight = _mockCartService.Object.WeightTotalInCart(_testCartOfProducts);

        //Assert
        Assert.True(resultUpdate.Success);
        Assert.Equal(testProduct.Weight * 3, resultWeight.Content.Weight);
    }

    [Fact]
    public void RemovingProduct_ShouldUpdateWeightToZero()
    {
        //Arrange
        var testProduct = CreateCartProduct("99d1e35d-32da-42d6-8598-e7d68d8b1083", "Tomat", "10", 10m, 1);
        _testCartOfProducts.Add(testProduct);

        _mockCartService
            .Setup(s => s.RemoveFromCart(testProduct.ProductId))
            .Returns(new CartResponse { Success = true });

        _mockCartService
            .Setup(s => s.WeightTotalInCart(It.IsAny<List<CartProduct>>()))
            .Returns(new CartResponse { Success = true, Content = new CartProduct { Weight = 0 } });

        //Act
        var resultRemove = _mockCartService.Object.RemoveFromCart(testProduct.ProductId);
        var resultWeight = _mockCartService.Object.WeightTotalInCart(_testCartOfProducts);

        //Assert
        Assert.True(resultRemove.Success);
        Assert.Equal(0, resultWeight.Content.Weight);
    }
}