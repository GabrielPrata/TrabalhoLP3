using System.Net.WebSockets;
using System.Text;

public class WebSocketNotificationService
{
    private readonly List<WebSocket> _clients = new();

    public async Task HandleWebSocketAsync(WebSocket webSocket)
    {
        _clients.Add(webSocket);
        var buffer = new byte[1024 * 4];

        while (webSocket.State == WebSocketState.Open)
        {
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            if (result.MessageType == WebSocketMessageType.Close)
            {
                _clients.Remove(webSocket);
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
            }
        }
    }

    public async Task NotifyAllAsync(string message)
    {
        var messageBuffer = Encoding.UTF8.GetBytes(message);
        foreach (var client in _clients.ToList())
        {
            if (client.State == WebSocketState.Open)
            {
                await client.SendAsync(new ArraySegment<byte>(messageBuffer), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }
}
