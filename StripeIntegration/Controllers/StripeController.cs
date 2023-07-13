using Microsoft.AspNetCore.Mvc;
using Stripe;
using System.Text.Json;

namespace StripeIntegration;

[ApiController]
[Route("[controller]")]
public class StripeController : ControllerBase
{
    private readonly IStripeService _stripeService;

    public StripeController(IStripeService stripeService)
    {
        _stripeService = stripeService;
    }

    [HttpGet("balance")]
    public IActionResult GetBalance()
    {
        var balance = _stripeService.GetBalance();
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(balance, options);

        return Ok(jsonString);
    }

    // New endpoint to list balance transactions with pagination
    [HttpGet("transactions")]
    public IActionResult GetBalanceTransactions(int limit, string? startingAfter = null)
    {
        var transactions = _stripeService.GetBalanceTransactions(limit, startingAfter);
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(transactions, options);

        return Ok(jsonString);
    }
}
