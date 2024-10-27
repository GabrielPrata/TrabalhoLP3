using StayManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayManager.Data.Decorator
{
    public interface IReserva
    {
        public decimal CalculaValorTotal();
    }
}
