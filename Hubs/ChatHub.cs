using Microsoft.AspNetCore.SignalR;

namespace TodoList.Hubs;

public class ChatHub : Hub
{
    private ILogger<ChatHub> logger;
    // TODO: have this in a service, and have chatroom names
    // to be able to reload the history per chat room
    private static List<string> messages = new();

    public ChatHub(ILoggerFactory LoggerFactory)
    {
        logger = LoggerFactory.CreateLogger<ChatHub>();
    }

    public async Task Reload(string connectionId)
    {
        logger.LogWarning($"Server side Reload: {connectionId}");
        logger.LogWarning($"Server side Reload: {messages.Count} messages");
        var client = Clients.Client(connectionId);
        logger.LogWarning($"Server side Reload: {client.ToString()}");
        await client.SendAsync("ReloadMessages", messages);
    }

    public async Task SendMessage(string message)
    {
        logger.LogWarning($"Server side SendMessage: {message}");
        messages.Add(message);
        logger.LogWarning($"Server side SendMessage: {messages.Count}");

        await Clients.All.SendAsync("ReceiveMessage", message);
    }
}