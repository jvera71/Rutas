using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;

namespace RutasApp.Services
{
    public class SignalRService : IAsyncDisposable
    {
        private HubConnection? _hubConnection;
        private readonly string _hubUrl;

        public SignalRService(string hubUrl)
        {
            _hubUrl = hubUrl;
        }

        public HubConnection HubConnection => _hubConnection ?? throw new InvalidOperationException("HubConnection not initialized. Call StartAsync first.");

        public async Task StartAsync()
        {
            if (_hubConnection != null) return;

            _hubConnection = new HubConnectionBuilder()
                .WithUrl(_hubUrl)
                .WithAutomaticReconnect()
                .Build();

            await _hubConnection.StartAsync();
        }

        public async ValueTask DisposeAsync()
        {
            if (_hubConnection != null)
            {
                await _hubConnection.DisposeAsync();
            }
        }
    }
}
