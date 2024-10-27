using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
