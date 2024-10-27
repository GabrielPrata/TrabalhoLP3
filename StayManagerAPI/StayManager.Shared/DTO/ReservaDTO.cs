
namespace StayManager.Shared.DTO
{
    public class ReservaDTO
    {
        public int Id { get; set; }

        public DateTime DataReserva { get; set; }
        public DateTime PeriodoInicial { get; set; }
        public DateTime PeriodoFinal { get; set; }
        public int IdCliente { get; set; }
        public int IdQuarto { get; set; }
        List<int> ServicosExtras { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
