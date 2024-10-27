using StayManager.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayManager.Core.Interfaces
{
    public interface IFazerReservaService
    {
        Task SalvarReserva(ReservaDTO reserva);
        Task DeletarReserva(int reservaId);
        Task<IEnumerable<ReservaDTO>> ListarReservas();

    }
}
