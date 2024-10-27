using StayManager.Data.Models;

namespace StayManager.Core.Interfaces
{
    internal interface IReservaObserver
    {
        void Update(ReservaModel reserva);
    }
}
