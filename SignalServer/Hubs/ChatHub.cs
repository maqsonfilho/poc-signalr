using Microsoft.AspNetCore.SignalR;

namespace SignalServer.Hubs
{
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("setClientMessage", $"A connection with ID ' {Context.ConnectionId} ' has just connected");
        }

        public async Task SendConnectionId(string connectionId)
        {
            await Clients.All.SendAsync("setClientMessage", "A connection with ID '" + connectionId + "' has just connected");
        }
    }
}
