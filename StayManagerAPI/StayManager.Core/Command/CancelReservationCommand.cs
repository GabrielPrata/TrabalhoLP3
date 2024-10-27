using StayManager.Core.Interfaces;
using StayManager.Core.Observer;
using StayManager.Data;
using System.Data.SqlClient;

namespace StayManager.Core.Command
{
    public class CancelReservationCommand : ICommander
    {
        private readonly WebSocketNotificationService _notificationService;
        private readonly int _reservationId;
        private readonly ReservaRepository _repository;

        public CancelReservationCommand(WebSocketNotificationService notificationService, int reservationId, string strConnection)
        {
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
            _reservationId = reservationId;
            _repository = new ReservaRepository(strConnection);
        }

        public async void Execute()
        {
            await _repository.DeletarReserva(_reservationId);

            // Lógica de cancelamento da reserva
            Console.WriteLine($"Reservation {_reservationId} has been cancelled.");

            // Notificar todos os usuários conectados via WebSocket
            await _notificationService.NotifyAllAsync($"Reservation {_reservationId} has been cancelled.");
        }
    }
}
