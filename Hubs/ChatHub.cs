using Microsoft.AspNetCore.SignalR;

namespace TodoList.Hubs;

public class ChatHub : Hub
{
    private Dictionary<string, string> messages = new();

    public async Task Reload(string connectionId)
    {
        await Clients.Client(connectionId).SendAsync("Reload", messages);
    }

    public async Task SendMessage(string user, string message)
    {
        messages[user] = message;

        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}