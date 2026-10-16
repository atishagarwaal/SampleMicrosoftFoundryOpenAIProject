# Sample Microsoft Foundry OpenAI Project

## 1. Overview

This repository contains a minimal .NET console application that connects to an Azure AI Foundry (Azure AI Projects/OpenAI-enabled) project and uses a deployed model to generate responses.

The sample demonstrates how to:
- authenticate to Azure using `DefaultAzureCredential`
- connect to an Azure AI Foundry or Azure AI Projects endpoint
- create a project-based Responses client
- send user prompts and display model responses in a simple command-line loop

## 2. Description

This sample is intended as a starting point for developers building AI-powered .NET applications that integrate with the Azure AI Foundry / Azure AI Projects service. The console app reads user input from the terminal, sends it to the configured model, and prints the generated response.

The code uses the Foundry project's Responses client to interact with the deployed model and demonstrates the basic flow: authenticate, create a client, send prompts, and display responses.

Key configuration values are defined in `SampleMicrosoftFoundryOpenAIProject/Program.cs`:
- `endpoint`: Azure AI Foundry / Azure AI Projects project endpoint (for example: https://services.ai.azure.com)
- `model`: deployed model name in your project
- `instructions`: system instructions for the assistant (optional)

### SDKs used

The project depends on the following NuGet packages (see the project file for exact versions):

```xml
<ItemGroup>
  <PackageReference Include="Azure.AI.Projects" Version="2.1.0-beta.4" />
  <PackageReference Include="Azure.Identity" Version="1.21.0" />
</ItemGroup>
```

The sample uses `Azure.AI.Projects` (the Azure AI Foundry/Projects SDK) along with `Azure.Identity` for authentication. The project demonstrates creating an `AIProjectClient` and obtaining a `ProjectResponsesClient` for a deployed model. Example client construction from `Program.cs`:

```csharp
// Create a project client with the endpoint and credential.
AIProjectClient projectClient = new(
    endpoint: new Uri(endpoint),
    tokenProvider: credential);

// Get a responses client for the model.
ProjectResponsesClient responseClient =
    projectClient.ProjectOpenAIClient.GetProjectResponsesClientForModel(model);
```

## 3. Prerequisites

Before running the sample, make sure you have:
- .NET 10 SDK installed
- An Azure subscription
- An Azure AI Foundry / Azure AI Projects project created in Azure
- A model deployed in your Foundry/Projects project
- Access to the project using an Azure identity

Sign in to Azure before running the app (example):

```bash
az login
```

`DefaultAzureCredential` will also work with Visual Studio, Visual Studio Code, Azure CLI, managed identities, and other supported credential sources.

## 4. Configure

Open `SampleMicrosoftFoundryOpenAIProject/Program.cs` and update the following variables to match your environment:

- `endpoint`: the project endpoint URL
- `model`: the deployed model name
- `instructions`: (optional) system instructions for the assistant

Ensure the endpoint string is a valid URI (include the scheme, e.g. `https://`).

## 5. Build and run

1. Clone the repository:

```bash
git clone https://github.com/atishagarwaal/SampleMicrosoftFoundryOpenAIProject.git
cd SampleMicrosoftFoundryOpenAIProject
```

2. Restore dependencies and build:

```bash
dotnet restore
dotnet build
```

3. Run the application:

```bash
dotnet run --project SampleMicrosoftFoundryOpenAIProject/SampleMicrosoftFoundryOpenAIProject.csproj
```

4. Enter prompts at the console. Type `quit` to exit.

Example interaction:

```text
Assistant: Enter a prompt (or type 'quit' to exit)

You: Hello!

Assistant: Hello! How can I help you today?
```

## 6. Notes & troubleshooting

- Make sure the `endpoint` and `model` values match your Azure AI Projects configuration.
- If you get authentication errors, verify that `az login` succeeded or that your environment provides a valid credential to `DefaultAzureCredential`.
- If the model is not responding, confirm the model is deployed and that your account has access to the project.

## 7. Contributing

Contributions, issues, and feature requests are welcome. Please open an issue or submit a pull request.

## 8. License

This repository does not contain a license file. Add a LICENSE file if you want to specify terms for reuse.
