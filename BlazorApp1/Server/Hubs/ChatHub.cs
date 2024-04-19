using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorApp1.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task JoinRoomAsync(string roomName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
            
            await Clients.Group(roomName).SendAsync("ReceiveMessage", $"{Context.ConnectionId} has joined the room {roomName}");
        }

        public async Task RemoveRoomAsync(string roomName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
            await Clients.Group(roomName).SendAsync("ReceiveMessage", $"{Context.ConnectionId} has left the group {roomName}.");
        }

        public async Task SendMessageAsync(string message, string roomName)
        {
            await Clients.Group(roomName).SendAsync("ReceiveMessage", $"{Context.ConnectionId}: {message}");
        }
    }
    
}


//https://learn.microsoft.com/ko-kr/aspnet/signalr/overview/guide-to-the-api/working-with-groups