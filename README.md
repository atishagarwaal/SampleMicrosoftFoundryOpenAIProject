# Sample Microsoft Foundry OpenAI Project

## 1. Overview
This repository contains a .NET console application that connects to an Azure AI Foundry project (or an Azure AI Projects/OpenAI-enabled project) and uses a deployed model to generate responses through the Azure AI Projects/Responses SDK.

The sample demonstrates how to:
- authenticate to Azure using `DefaultAzureCredential`
- connect to an Azure AI Foundry endpoint (or an Azure AI Projects endpoint)
- create a project-based OpenAI/Responses client
- send prompts and print model responses in a simple command-line loop

## 2. Description
This project is a minimal sample for working with Microsoft Azure AI Foundry / Azure AI Projects in a .NET application. It uses the `Azure.AI.Projects` and `Azure.Identity` libraries to authenticate and interact with a Foundry project and its deployed model.

The app reads user input from the terminal, sends it to the configured model, and prints the generated response. It is intended as a starting point for developers building AI-powered .NET applications.

The OpenAI Responses API brings together capabilities from previously separate APIs (ChatCompletions and Assistants) in a unified experience. This sample uses the Foundry project's Responses client to call a deployed model.

The key configuration values are defined in `SampleMicrosoftFoundryOpenAIProject/Program.cs`:
- `endpoint`: Azure AI Foundry project endpoint
- `model`: deployed model name
- `instructions`: system instructions for the assistant

### SDKs Used
This project uses the Microsoft Foundry SDK (`Azure.AI.Projects`) — the Azure AI Foundry SDK for .NET — as the primary SDK. It is not using the raw OpenAI SDK directly but interacts with the project's responses surface.

It also uses `Azure.Identity` for authentication. The code may import OpenAI-related types via `Azure.AI.Extensions.OpenAI` or `OpenAI.Responses`, but those are consumed through the Azure Foundry/Projects client.

Relevant project lines:

From the project file (`SampleMicrosoftFoundryOpenAIProject/SampleMicrosoftFoundryOpenAIProject.csproj`):

```xml
<ItemGroup>
  <PackageReference Include="Azure.AI.Projects" Version="2.1.0-beta.4" />
  <PackageReference Include="Azure.Identity" Version="1.21.0" />
</ItemGroup>
```

From `SampleMicrosoftFoundryOpenAIProject/Program.cs` (client construction):

```csharp
// Create a project client with the endpoint and credential.
AIProjectClient projectClient = new(
    endpoint: new Uri(endpoint),
    tokenProvider: credential);

// Get a responses client for the model.
ProjectResponsesClient responseClient =
    projectClient.ProjectOpenAIClient.GetProjectResponsesClientForModel(model);
```

The configured endpoint in the sample typically points to an Azure AI Foundry or Azure AI Projects endpoint (for example, services.ai.azure.com), which indicates Foundry/Projects integration.

## 3. Pre-requisites
Before running the project, make sure you have:
- .NET 10 SDK installed
- An Azure subscription
- An Azure AI Foundry / Azure AI Projects project created in Azure
- A deployed model in your Foundry/Projects project
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

2. Update the Azure AI Foundry/Projects configuration in `SampleMicrosoftFoundryOpenAIProject/Program.cs`:
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
This sample is intentionally simple and is designed to help you understand the basic flow for integrating Azure AI Foundry / Azure AI Projects with a .NET application.
