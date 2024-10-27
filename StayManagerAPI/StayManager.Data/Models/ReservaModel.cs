using StayManager.Data.Decorator;

namespace StayManager.Data.Models
{
    public class ReservaModel : IReserva
    {
        protected IReserva reservaDecorada;

        public DateTime DataReserva { get; set; }
        public DateTime PeriodoInicial { get; set; }
        public DateTime PeriodoFinal { get; set; }
        public string NomeCliente { get; set; }
        public string TipoQuarto { get; set; }
        public string? ServicosExtras { get; set; }
        public decimal ValorTotal { get; set; }

        public decimal CalculaValorTotal()
        {
           return ValorTotal;
        }
    }
}
