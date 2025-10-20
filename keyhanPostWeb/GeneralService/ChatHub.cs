using Microsoft.AspNetCore.SignalR;

namespace keyhanPostWeb.GeneralService
{
    public class ChatHub : Hub
    {
        // متدی برای ارسال پیام به همه
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }

}
