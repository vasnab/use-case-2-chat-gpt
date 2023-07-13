using Xunit;
using Moq;
using Stripe;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using StripeIntegration;
using Microsoft.Extensions.Options;

namespace StripeIntegrationTests;

public class StripeControllerTest
{
    private readonly StripeController _controller;
    private readonly Mock<IStripeService> _stripeServiceMock;

    public StripeControllerTest()
    {
        _stripeServiceMock = new Mock<IStripeService>();
        _controller = new StripeController(_stripeServiceMock.Object);
    }

    [Fact]
    public void GetBalance_ReturnsBalance()
    {
        // Arrange
        var balance = new Balance();
        _stripeServiceMock.Setup(service => service.GetBalance()).Returns(balance);

        // Act
        var result = _controller.GetBalance();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<string>(okResult.Value);
        Assert.NotNull(returnValue);
    }

    [Fact]
    public void GetBalanceTransactions_ReturnsTransactions()
    {
        // Arrange
        var transactions = new StripeList<BalanceTransaction>
        {
            Data = new List<BalanceTransaction>()
        };

        _stripeServiceMock.Setup(service => service.GetBalanceTransactions(1, null)).Returns(transactions);

        // Act
        var result = _controller.GetBalanceTransactions(1, null);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<string>(okResult.Value);
        Assert.NotNull(returnValue);
    }
}
