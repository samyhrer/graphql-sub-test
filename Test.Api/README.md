This example contains a API that exposes a grapql endpoint supporting supbscriptions.

subscription symbolUpdated($variableNames: [String]!) {
    symbolUpdated(variableNames: $variableNames) {
    value
    name
    timeStamp
    }
}

It contains a simple React App that uses the Apollo Client to create multiple subscriptions against the graphql endpoint.

How To Run
==========
This example app contains a prebuilt Client side app in wwwroot/demo/build

- Goto folder Test.Api
- dotnet restore
- dotnet run
- Open browser on localhost:50166/demo/build/index.html

How to Build the client side app
================================
- Goto Test.Api/wwwroot/demo
- yarn
- yarn build



