using StayManager.Core.Interfaces;
using StayManager.Data.Models;

namespace StayManager.Core.Observer
{
    public class ReservationPublisher
    {
        private readonly List<IReservaObserver> _subscribers = new List<IReservaObserver>();

        public void Subscribe(IReservaObserver subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public void Unsubscribe(IReservaObserver subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        public void Notify(string message)
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.Update(message);
            }
        }
    }


}
