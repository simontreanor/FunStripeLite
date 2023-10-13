namespace FunStripe

open System

module Config =

    //Parameter attributes for Stripe Requests
    type FormAttribute() = inherit Attribute()
    type PathAttribute() = inherit Attribute()
    type QueryAttribute() = inherit Attribute()

    /// Defines the base URL for the Stripe API
    let StripeBaseUrl = "https://api.stripe.com"
