using Microsoft.AspNetCore.Mvc;
using Stripe;
using System.Text.Json;

namespace StripeIntegration;

[ApiController]
[Route("[controller]")]
public class StripeController : ControllerBase
{
    private readonly StripeService _stripeService;

    public StripeController(StripeService stripeService)
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

    [HttpGet("transactions")]
    public IActionResult GetTransactions([FromQuery] int limit = 10)
    {
        var options = new BalanceTransactionListOptions
        {
            Limit = limit
        };
        var transactions = _stripeService.GetBalanceTransactions(options);
        return Ok(transactions);
    }
}
