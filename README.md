# Sample Microsoft Foundry OpenAI Project

## 1. Overview
This repository contains a .NET console application that connects to an Azure AI Foundry endpoint and uses a deployed model to generate responses through the OpenAI .NET SDK.

The sample demonstrates how to:
- authenticate to Azure using `DefaultAzureCredential`
- connect to an Azure AI Foundry endpoint
- create an `OpenAIClient` and `ResponsesClient`
- send prompts and print model responses in a simple command-line loop

## 2. Description
This project is a minimal sample for working with Azure AI Foundry and the OpenAI .NET SDK in a .NET application. It uses the `OpenAI` and `Azure.Identity` libraries to authenticate and interact with a Foundry-hosted model.

The app reads user input from the terminal, sends it to the configured model, and prints the generated response. It is intended as a starting point for developers building AI-powered .NET applications that use a Microsoft Azure AI Foundry endpoint.

The OpenAI Responses API enables a unified pattern for sending prompts and receiving structured model responses. This sample uses the Foundry endpoint as the back-end and authenticates with Microsoft Entra ID through `DefaultAzureCredential`.

The key configuration values are defined in `SampleMicrosoftFoundryOpenAIProject/Program.cs`:
- `endpoint`: Azure AI Foundry project endpoint
- `model`: deployed model name
- `instructions`: system instructions for the assistant

### SDKs Used
This project uses the OpenAI .NET SDK (`OpenAI`) as the primary client library and `Azure.Identity` for authentication. The code uses a custom bearer token policy scoped to `https://ai.azure.com/.default` and then creates an `OpenAIClient` with the Azure AI Foundry endpoint.

This sample is not using the `Azure.AI.Projects` SDK in the project file. The actual package references in the project are:

From the project file (`SampleMicrosoftFoundryOpenAIProject/SampleMicrosoftFoundryOpenAIProject.csproj`):

```xml
<ItemGroup>
  <PackageReference Include="Azure.Identity" Version="1.21.0" />
  <PackageReference Include="OpenAI" Version="2.14.0" />
</ItemGroup>
```

From `SampleMicrosoftFoundryOpenAIProject/Program.cs` (client construction):

```csharp
DefaultAzureCredential credential = new(new DefaultAzureCredentialOptions
{
    ExcludeManagedIdentityCredential = true,
    ExcludeWorkloadIdentityCredential = true,
});

BearerTokenPolicy tokenPolicy = new(credential, "https://ai.azure.com/.default");
OpenAIClient openAIClient = new(
    authenticationPolicy: tokenPolicy,
    options: new OpenAIClientOptions
    {
        Endpoint = new Uri(endpoint),
    });

ResponsesClient responseClient = openAIClient.GetResponsesClient();
```

The configured endpoint in the sample points to an Azure AI Foundry `services.ai.azure.com` endpoint, which confirms the Foundry integration.

## 3. Pre-requisites
Before running the project, make sure you have:
- .NET 10 SDK installed
- An Azure subscription
- An Azure AI Foundry project created in Azure
- A deployed model in your Foundry project
- Access to the project with a valid Azure identity

You should also sign in to Azure before running the app, for example:

```bash
az login
```

If you are using Visual Studio, Visual Studio Code, or another supported Azure credential source, those will also work with `DefaultAzureCredential`.

## 4. Build and Run
1. Clone the repository:

```bash
git clone https://github.com/atishagarwaal/SampleMicrosoftFoundryOpenAIProject.git
cd SampleMicrosoftFoundryOpenAIProject
```

2. Update the Azure AI Foundry configuration in `SampleMicrosoftFoundryOpenAIProject/Program.cs`:
- set the correct `endpoint`
- set the correct `model`
- confirm the `instructions` match your scenario

3. Restore dependencies and build the project:

```bash
dotnet restore
dotnet build
```

4. Run the application:

```bash
dotnet run --project SampleMicrosoftFoundryOpenAIProject/SampleMicrosoftFoundryOpenAIProject.csproj
```

5. Enter a prompt in the terminal. Type `quit` to exit the app.

Example:

```text
Assistant: Enter a prompt (or type 'quit' to exit)

You: Hello!

Assistant: Hello! How can I help you today?
```

## Notes
This sample is intentionally simple and is designed to help you understand the basic flow for integrating Azure AI Foundry with a .NET application using the OpenAI .NET SDK and Azure Identity.
