using Microsoft.Extensions.AI;
using OllamaSharp;


//IChatClient chatClient = new OllamaApiClient(new Uri("http://localhost:11434/"), "gpt-oss:20b");
IChatClient chatClient = new OllamaApiClient(new Uri("http://localhost:11434/"), "llama3");

List<ChatMessage> messages = new ();

//Console.WriteLine("Chat GPT-OSS - tipe exit to quit");
Console.WriteLine("Chat llama3 - tipe exit to quit");

Console.WriteLine();

while (true)
{

    Console.WriteLine("You:");
    var userInput = Console.ReadLine();

    if (userInput?.ToLower().Trim() == "exit")
        break;

    if (string.IsNullOrWhiteSpace(userInput))
        continue;

    messages.Add(new ChatMessage(ChatRole.User, userInput!));

    Console.WriteLine("Chat: ");

    try
    {
        var response = "";

        await foreach (var update in chatClient.GetStreamingResponseAsync(messages))
        {
            Console.Write(update.Text);
            response += update.Text;
        }

        Console.WriteLine();
        messages.Add(new ChatMessage(ChatRole.Assistant, response));
        Console.WriteLine("");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\nErro na comunicação com o chat: {ex.Message}");
    }

}