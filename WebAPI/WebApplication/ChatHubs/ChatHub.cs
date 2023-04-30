using Microsoft.AspNetCore.SignalR;
using MyMessager.Models;

namespace SinglRServer.ChatHubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
