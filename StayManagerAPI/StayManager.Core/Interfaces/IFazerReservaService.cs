using StayManager.Data.DTO;

namespace StayManager.Core.Interfaces
{
    public interface IFazerReservaService
    {
        Task SalvarReserva(ReservaDTO reserva);
        Task DeletarReserva(int reservaId);
        Task<IEnumerable<ReservaDTO>> ListarReservas();

    }
}
