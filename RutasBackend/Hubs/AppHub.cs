using Microsoft.AspNetCore.SignalR;

namespace RutasBackend.Hubs
{
    public class AppHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
