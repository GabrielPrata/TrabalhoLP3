namespace StayManager.Data.Decorator
{
    public class CafeDaManha : ReservaDecorator
    {
        public CafeDaManha(IReserva reserva) : base(reserva) { }
        public override decimal CalculaValorTotal()
        {
           return 50;
        }
    }
}
