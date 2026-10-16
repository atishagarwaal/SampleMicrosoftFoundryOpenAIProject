# SampleMicrosoftFoundryOpenAIProject

## Overview

This repository contains a sample C# project demonstrating how to build and run an application that integrates with Microsoft Foundry and OpenAI services. It provides example code and configuration to help you get started quickly.

## Description

The project is implemented in C# and targets .NET. It includes sample code showing how to call OpenAI APIs, handle authentication, and process responses. Use this repository as a reference or starting point for integrating OpenAI capabilities into your .NET applications.

## Pre-requisites

- .NET SDK 6.0 or later installed (download from https://dotnet.microsoft.com/)
- Visual Studio 2022 / Visual Studio Code or another C# IDE/text editor
- (Optional) An OpenAI API key or Microsoft Foundry credentials if you plan to run the samples that call external services
- Git (to clone the repository)

## SDKs and Libraries Used

This project depends on the .NET SDK and one or more client libraries for interacting with OpenAI or Azure OpenAI services. Below are recommended packages and installation commands.

- .NET SDK: 6.0 or later (required)

- Azure OpenAI (official Azure SDK, use when targeting Azure OpenAI Service):

  Installation:

    dotnet add package Azure.AI.OpenAI

  Usage notes:
  - This library provides strongly-typed clients for working with Azure OpenAI endpoints and is recommended if you deploy via Azure or Microsoft Foundry.
  - Configure endpoint and key using environment variables or appsettings.json.

- OpenAI (third-party / community .NET clients) — use if calling the OpenAI API directly:

  - There are community-maintained SDKs (e.g., OpenAI-DotNet). If you prefer not to use a community SDK, you can call the REST API directly with HttpClient.

- Configuration & helpers (recommended):

  - Microsoft.Extensions.Configuration
  - Microsoft.Extensions.Configuration.UserSecrets (for local secret storage during development)

  Example:

    dotnet add package Microsoft.Extensions.Configuration
    dotnet add package Microsoft.Extensions.Configuration.UserSecrets

Configuration tips:
- Store API keys in environment variables or user secrets rather than hard-coding them. Example env var names used in this README: OPENAI_API_KEY and AZURE_OPENAI_ENDPOINT / AZURE_OPENAI_KEY.
- For Azure.AI.OpenAI, set AZURE_OPENAI_ENDPOINT to your endpoint URL and AZURE_OPENAI_KEY to the credential.

## Build and Run

1. Clone the repository:

   git clone https://github.com/atishagarwaal/SampleMicrosoftFoundryOpenAIProject.git
   cd SampleMicrosoftFoundryOpenAIProject

2. Restore dependencies and build the project:

   dotnet restore
   dotnet build

3. Run the project:

   dotnet run --project <PathToProjectFile.csproj>

   Or open the solution in Visual Studio and run from the IDE.

4. Configuration:

   - If the sample requires API keys, add them to user secrets, environment variables, or an appsettings.json as appropriate. For example, to use an environment variable:

     - Linux/macOS:
       export OPENAI_API_KEY="your_api_key_here"

     - Windows (PowerShell):
       $env:OPENAI_API_KEY = "your_api_key_here"

     - For Azure OpenAI (example):
       export AZURE_OPENAI_ENDPOINT="https://your-resource.openai.azure.com/"
       export AZURE_OPENAI_KEY="your_key_here"

5. Troubleshooting:

   - Ensure the .NET SDK version matches the target framework of the project files.
   - Verify NuGet packages are restored successfully.
   - Check the README or comments in sample files for any additional configuration steps or environment variables required.


---

If you'd like, I can update the README to reference the exact NuGet packages and versions used by the project (I can inspect the project files to pick the correct packages), add example code snippets showing how to construct the client, or add LICENSE and CONTRIBUTING sections — tell me which details to include and I'll update the file.