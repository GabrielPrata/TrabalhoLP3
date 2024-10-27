namespace StayManager.Data.DTO
{
    public class ReservaDTO
    {
        public int Id { get; set; }
        public DateTime DataReserva { get; set; }
        public DateTime PeriodoInicial { get; set; }
        public DateTime PeriodoFinal { get; set; }
        public  string NomeCliente { get; set; }
        public string TipoQuarto { get; set; }
        public string? ServicosExtras { get; set; }

        public decimal ValorTotal { get; set; }
    }
}
