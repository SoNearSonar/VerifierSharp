# VerifierSharp
## A client for the Verifier Web API, written in C#/NET

## Features:
- Asynchronous method calls
- Written in .NET 6.0

## NuGet Package:
[![VerifierSharp NuGet](https://img.shields.io/nuget/vpre/VerifierSharp?label=VerifierSharp&style=for-the-badge)](https://www.nuget.org/packages/VerifierSharp/)

## Credits:
[Meetvchopra](https://twitter.com/meetvchopra)

## API Key
You can get an API key to use with this project [here](https://verifier.meetchopra.com/)

## Usage:
Checking an email address
```csharp
VerifierClient client = new VerifierClient("your_api_key_here");

VerifierResponse response = await client.VerifyEmailAddressAsync("test@gmai.com");

if (!response.Status)
{
    Console.WriteLine("Error! " + response.Error.Message);
} 
else 
{
    Console.WriteLine("Email address is not disposable");
}
```
