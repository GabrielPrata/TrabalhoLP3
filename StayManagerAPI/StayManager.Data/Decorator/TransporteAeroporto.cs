namespace StayManager.Data.Decorator
{
    public class TransporteAeroporto : ReservaDecorator
    {
        public TransporteAeroporto(IReserva reserva) : base(reserva) { }

        public override decimal CalculaValorTotal()
        {
            return 150;
        }
    }
}
