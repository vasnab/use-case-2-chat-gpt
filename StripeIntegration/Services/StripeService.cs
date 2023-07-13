using Stripe;
using Microsoft.Extensions.Options;

public class StripeService
{
    private readonly string _apiKey = "sk_test_51NTLYOLcrZqS336YAiGKS4M7BTxuKEMsJH9dYt2ZBss7WvMJ8av5LyTzgkgLbkvUkkbFERQdjNr3NztXW1AEtE5000W0TNyrts";

    public StripeService(IOptions<StripeSettings> options)
    {
        _apiKey = options.Value.ApiKey;
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
            throw new Exception("Stripe API Error: " + ex.Message);
        }
    }

    public StripeList<BalanceTransaction> GetBalanceTransactions(BalanceTransactionListOptions options)
    {
        var service = new BalanceTransactionService();
        return service.List(options);
    }
}
