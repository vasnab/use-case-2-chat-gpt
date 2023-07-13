using Stripe;

namespace StripeIntegration;

public interface IStripeService
{
    Balance GetBalance();
    StripeList<BalanceTransaction> GetBalanceTransactions(int limit, string? startingAfter);
}
