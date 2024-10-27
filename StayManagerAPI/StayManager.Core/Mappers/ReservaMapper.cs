using StayManager.Data.DTO;
using StayManager.Data.Models;
namespace StayManager.Core.Mappers
{
    internal static class ReservaMapper
    {
        public static ReservaModel ToModel(this ReservaDTO dto)
        {
            return new ReservaModel
            {
                DataReserva = dto.DataReserva,
                PeriodoInicial = dto.PeriodoInicial,
                PeriodoFinal = dto.PeriodoFinal,
                NomeCliente = dto.NomeCliente,
                ServicosExtras = dto.ServicosExtras,
                ValorTotal = dto.ValorTotal,
                TipoQuarto = dto.TipoQuarto,
            };
        }

        public static ReservaDTO ToDto(this ReservaModel model)
        {
            return new ReservaDTO
            {
                DataReserva = model.DataReserva,
                PeriodoInicial = model.PeriodoInicial,
                PeriodoFinal = model.PeriodoFinal,
                NomeCliente = model.NomeCliente,
                ServicosExtras = model.ServicosExtras,
                ValorTotal = model.ValorTotal,
                TipoQuarto = model.TipoQuarto,
            };
        }
    }
}
