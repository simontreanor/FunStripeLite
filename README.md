# FunStripeLite

A lightweight F# library to connect to the Stripe API. Targets .NET Framework 4.7.2, .NET Standard 2.1  and .NET 6.

## Latest updates

2023-10-13: version 1.3.1 restores a small number of utility functions that are not required by the library but are very useful for serialising Stripe objects.

2023-10-13: version 1.3.0 fixes an issue with form serialisation that meant that JsonField names were only applied to the top level elements. It also tidies the code up a little.

2023-08-29: version 1.2.3 updates the Stripe API from version 2022-11-15 to 2023-08-16, which contains some breaking changes. See the [Stripe API changelog](https://stripe.com/docs/upgrades#api-changelog) for details.

2023-06-29: version 1.2.2 updates the package dependencies for FSharp.Core and FSharp.Data to 6.0.7 and 6.2.0 respectively.

2022-11-22: version 1.2.0 updates the Stripe API from version 2022-08-01 to 2022-11-15, which contains some breaking changes. See the [Stripe API changelog](https://stripe.com/docs/upgrades#api-changelog) for details. As .NET 5 is out-of-support, this has been removed from the target frameworks.

2022-10-05: version 1.1.0 updates the Stripe API from version 2020-08-27 to 2022-08-01, which contains some breaking changes. See the [Stripe API changelog](https://stripe.com/docs/upgrades#api-changelog) for details.

2022-04-22: FunStripeLite version 1.0.0 forked from FunStripe and stripped down

## Installation

Get the latest version from [Nuget](https://www.nuget.org/packages/FunStripeLite/)

## Usage

Open the StripeModel and StripeRequest modules.

Here's an example of how to create a new payment method:

```F#
let settings = RestApi.StripeApiSettings.New(apiKey = "<your Stripe API key>")

let defaultCard =
    PaymentMethods.CreateCardCardDetailsParams.New(
        cvc = "314",
        expMonth = 10,
        expYear = 2021,
        number = "4242424242424242"
    )

let getNewPaymentMethod () =
    asyncResult {
        return! 
            PaymentMethods.CreateOptions.New(
                card = Choice1Of2 defaultCard,
                type' = PaymentMethods.CreateType.Card
            )
            |> PaymentMethods.Create settings
    }
```

The result value is an `AsyncResult<PaymentMethod,ErrorResponse>`, giving you the requested object in case of success or a detailed error response if not.

The general format of API requests is `<module>`.`<method>` `settings` `options`.

To instantiate the `settings` you need to pass in your Stripe API key. Having local rather than global settings allows you to use different keys for different Stripe accounts if you need to.

The `options` can be provided using record notation or if there are many uninitialised properties you can use the static `New` method to instantiate the record more effiently.

## References

[Stripe Documentation](https://stripe.com/docs)

[Developer Tools](https://stripe.com/docs/development)

[API Reference](https://stripe.com/docs/api)

[Official Stripe .NET Library](https://github.com/stripe/stripe-dotnet)

[Stripe OpenAPI Specification](https://raw.githubusercontent.com/stripe/openapi/master/openapi/spec3.sdk.json)
