namespace VegyesBolt.API.Services
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.SignalR;

    /// <summary>
    /// Signalhub.
    /// </summary>
    public class SignalRHub : Hub
    {
        /// <inheritdoc/>
        public override Task OnConnectedAsync()
        {
            this.Clients.Caller.SendAsync("Connected", this.Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        /// <inheritdoc/>
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            this.Clients.Caller.SendAsync("Disconnected", this.Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }

}
