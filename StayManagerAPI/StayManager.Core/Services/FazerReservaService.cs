using StayManager.Core.Command;
using StayManager.Core.FactoryMethod;
using StayManager.Core.Interfaces;
using StayManager.Core.Mappers;
using StayManager.Core.Observer;
using StayManager.Data;
using StayManager.Data.Decorator;
using StayManager.Data.DTO;
using StayManager.Data.Models;
using System.Data.SqlClient;

namespace StayManager.Core.Services
{
    public class FazerReservaService : IFazerReservaService
    {
        private readonly ReservaRepository _repository;
        private readonly ReservationPublisher _publisher;
        private readonly WebSocketNotificationService _notificationService;
        private string _connectionString;

        public FazerReservaService(string strConnection, WebSocketNotificationService notificationService)
        {
            _connectionString = strConnection;
            _repository = new ReservaRepository(strConnection);
            _publisher = new ReservationPublisher();
            _notificationService = notificationService;
        }


        public async Task SalvarReserva(ReservaDTO reserva)
        {

            var model = ReservaMapper.ToModel(reserva);

            QuartoModel quarto = QuartoFactory.GetQuarto(model.TipoQuarto);

            quarto.AtribuirValores();
            model.ValorTotal = quarto.Preco;

            if(reserva.ServicosExtras != "null")
            {
                decimal totalsoma = ServicoDecoratorFactory.AplicarServicos(model, reserva.ServicosExtras, reserva.ValorTotal);
                model.ValorTotal += totalsoma;
            }


            TimeSpan diferenca = model.PeriodoInicial - model.PeriodoFinal;

            int totalDias = Math.Abs(diferenca.Days);

            model.ValorTotal = model.ValorTotal * totalDias;  


            await _repository.SalvarReserva(model);

        }


        public async Task DeletarReserva(int reservaId)
        {
            CancelReservation(reservaId);

        }

        public async Task<IEnumerable<ReservaDTO>> ListarReservas()
        {
            var reservas = await _repository.ListarReservas();
            return reservas;

        }

        private void CancelReservation(int reservationId)
        {
            var cancelCommand = new CancelReservationCommand(_notificationService, reservationId, _connectionString);
            cancelCommand.Execute();
        }

    }
}
