using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorApp1.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task JoinRoomAsync(string userid, string roomName)
        {
            // DB 검증로직 
            //          - 필요없을수도
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
            
            await Clients.Group(roomName).SendAsync("ReceiveMessage", $"{Context.ConnectionId} has joined the room {roomName}");
        }

        public async Task RemoveRoomAsync(string userid, string roomName)
        {
            // DB 검증로직
            //          - 필요없을수도
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
            await Clients.Group(roomName).SendAsync("ReceiveMessage", $"{Context.ConnectionId} has left the group {roomName}.");
        }

        public async Task SendMessageAsync(string message, string roomName)
        {
            //await Clients.Group(roomName).SendAsync("ReceiveMessage", $"{Context.ConnectionId}: {message}");
            await Clients.Group(roomName).SendAsync("ReceiveMessage", $"{message}");
        }

    }
    
}


//https://learn.microsoft.com/ko-kr/aspnet/signalr/overview/guide-to-the-api/working-with-groups