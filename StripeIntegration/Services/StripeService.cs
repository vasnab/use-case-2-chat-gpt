using Stripe;
using Microsoft.Extensions.Options;
using StripeIntegration;

namespace StripeIntegration;
public class StripeService : IStripeService
{
    private readonly string _apiKey = "sk_test_51NTLYOLcrZqS336YAiGKS4M7BTxuKEMsJH9dYt2ZBss7WvMJ8av5LyTzgkgLbkvUkkbFERQdjNr3NztXW1AEtE5000W0TNyrts";

    public StripeService(IOptions<StripeSettings> options)
    {
        StripeConfiguration.ApiKey = _apiKey;
    }

    public Balance GetBalance()
    {
        try
        {
            var balanceService = new BalanceService();
            Balance stripeBalance = balanceService.Get();

            return stripeBalance;
        }
        catch (StripeException ex)
        {
            throw new StripeServiceException("Stripe API Error: " + ex.Message);
        }
    }

    // Method to get balance transactions with pagination
    public StripeList<BalanceTransaction> GetBalanceTransactions(int limit, string? startingAfter)
    {
        try
        {
            var service = new BalanceTransactionService();
            var options = new BalanceTransactionListOptions
            {
                Limit = limit,
            };
            if (!string.IsNullOrEmpty(startingAfter))
            {
                options.StartingAfter = startingAfter;
            }
            var transactions = service.List(options);
            return transactions;
        }
        catch (StripeException ex)
        {
            throw new StripeServiceException("Stripe API Error: " + ex.Message);
        }
    }
}
