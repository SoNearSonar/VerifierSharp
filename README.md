# VerifierSharp
## A client for the Verifier Web API, written in C#/NET

## Features:
- Asynchronous method calls
- Written in .NET 6.0

## Credits:
[Meetvchopra](https://twitter.com/meetvchopra)

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
