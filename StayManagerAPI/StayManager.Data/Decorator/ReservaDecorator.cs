using StayManager.Data.Models;

namespace StayManager.Data.Decorator
{

    public class ReservaDecorator : IReserva
    {
        protected IReserva reservaDecorada;

        public ReservaDecorator(IReserva reserva)
        {
            reservaDecorada = reserva;
        }

        protected IReserva reservaDecorator;

        public int Id { get; set; }

        public DateTime DataReserva { get; set; }
        public DateTime PeriodoInicial { get; set; }
        public DateTime PeriodoFinal { get; set; }
        public ClienteModel Cliente { get; set; }
        public string TipoQuarto { get; set; }
        public QuartoModel Quarto { get; set; }
        public string? ServicosExtras { get; set; }
        public decimal ValorTotal { get; set; }

        public virtual decimal CalculaValorTotal()
        {
          return ValorTotal;
        }
    }
}
