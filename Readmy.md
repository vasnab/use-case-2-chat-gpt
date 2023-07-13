Application Description

This application is designed to facilitate Stripe API integration and provide a convenient interface for interacting with the Stripe's balance and balance transactions endpoints. It is built upon ASP.NET Core and uses Stripe.NET SDK to communicate with the Stripe API. By encapsulating Stripe API calls within a separate service, it allows easy querying of the current balance and transaction history with a user-friendly interface.

The main feature of this application is its two web API endpoints. One returns the current balance in a Stripe account, and the other allows retrieval of balance transactions with optional pagination. Both endpoints return well-formatted JSON responses for easy interpretation. The application also includes a custom exception class, StripeServiceException, designed specifically for handling any exceptions related to the Stripe service, ensuring clear and meaningful error messages are propagated when issues arise.

Running the Application Locally

To run the application locally, you will need to follow these steps:

    Clone the repository to your local machine.

    Install the necessary dependencies. This project primarily uses Microsoft ASP.NET Core, the Stripe.NET SDK, and JSON handling libraries. You can do this by running the command:

dotnet restore

Update the _apiKey variable in the StripeService.cs with your own Stripe API key.

Run the application with the following command:

arduino

    dotnet run

Your local server should now be running and you can access the application through a web browser or API client like Postman at http://localhost:5000 (or https://localhost:5001 for HTTPS).
Example URLs

Here are example URLs to interact with the developed endpoints:

    Get current balance:

    bash

http://localhost:5000/Stripe/balance

Get balance transactions:

bash

    http://localhost:5000/Stripe/transactions?limit=10&startingAfter=txn_1JbKNEEzv3ZEq9Tlo8v8Qhao

Please replace localhost:5000 with the server address and port you are using. The limit query parameter in the transactions endpoint indicates the maximum number of transactions to be returned, while startingAfter represents the ID of the last data from the previous page, used for pagination.