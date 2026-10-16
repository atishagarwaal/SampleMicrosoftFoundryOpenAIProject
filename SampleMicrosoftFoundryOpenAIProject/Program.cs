// dotnet add package OpenAI
// dotnet add package Azure.Identity --version 1.21.0
using Azure.Identity;
using OpenAI;
using OpenAI.Responses;
using System.ClientModel.Primitives;

#pragma warning disable OPENAI001

const string endpoint = "https://aatishfoundry2026.services.ai.azure.com/openai/v1/";
const string model = "gpt-6-sol";
const string instructions = "You are a helpful AI assistant that answers questions clearly and concisely.";

DefaultAzureCredential credential = new(new DefaultAzureCredentialOptions
{
    ExcludeManagedIdentityCredential = true,
    ExcludeWorkloadIdentityCredential = true,
});

// Authenticate with Microsoft Entra ID and call the model through the OpenAI client.
BearerTokenPolicy tokenPolicy = new(credential, "https://ai.azure.com/.default");
OpenAIClient openAIClient = new(
    authenticationPolicy: tokenPolicy,
    options: new OpenAIClientOptions
    {
        Endpoint = new Uri(endpoint),
    });

// Get the responses client for the OpenAI client.
ResponsesClient responseClient = openAIClient.GetResponsesClient();

string? lastResponseId = null;

Console.WriteLine("Assistant: Enter a prompt (or type 'quit' to exit)");
while (true)
{
     // Loop until the user quits.
    Console.Write("\nYou: ");
    string? inputText = Console.ReadLine();
    if (inputText is null || inputText.Equals("quit", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("Assistant: Goodbye!");
        break;
    }

    // Send message to the model and create response options.
    CreateResponseOptions options = new()
    {
        Model = model,
        Instructions = instructions,
        PreviousResponseId = lastResponseId,
        InputItems = { ResponseItem.CreateUserMessageItem(inputText) },
    };

    // Create response.
    var response = responseClient.CreateResponse(options);

    // Write the response to the console.
    Console.WriteLine($"\nAssistant: {response.Value.GetOutputText()}");
    
    // Set the last response ID to the ID of the response.
    lastResponseId = response.Value.Id;
}
