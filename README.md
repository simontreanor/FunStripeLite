# FunStripeLite

A lightweight F# 5.0 library to connect to the Stripe API.

## Latest updates

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
