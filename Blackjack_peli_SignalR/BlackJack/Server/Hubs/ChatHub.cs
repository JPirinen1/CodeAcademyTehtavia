using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using BlackJack.Shared;

namespace BlackJack.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(User user)
        {
            user.ts = DateTime.Now;
            await Clients.All.SendAsync("ReceiveMessage", user);
        }
    }
}
