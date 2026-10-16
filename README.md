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

5. Troubleshooting:

   - Ensure the .NET SDK version matches the target framework of the project files.
   - Check the README or comments in sample files for any additional configuration steps or environment variables required.


---

If you'd like, I can tailor the README with exact project names, framework targets, example env variable names, or add a License and Contribution section — tell me which details to include and I'll update the file.