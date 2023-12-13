using Microsoft.AspNetCore.SignalR;

namespace TodoList.Hubs;

public class ChatHub : Hub
{
    private ILogger<ChatHub> logger;
    private List<string> messages = new();

    public ChatHub(ILoggerFactory LoggerFactory)
    {
        logger = LoggerFactory.CreateLogger<ChatHub>();
    }

    public async Task Reload(string connectionId)
    {
        logger.LogWarning($"Server side Reload: {connectionId}");
        logger.LogWarning($"Server side Reload: {messages.Count} messages");
        await Clients.Client(connectionId).SendAsync("ReloadMessages", messages);
    }

    public async Task SendMessage(string message)
    {
        logger.LogWarning($"Server side SendMessage: {message}");
        messages.Add(message);

        await Clients.All.SendAsync("ReceiveMessage", message);
    }
}