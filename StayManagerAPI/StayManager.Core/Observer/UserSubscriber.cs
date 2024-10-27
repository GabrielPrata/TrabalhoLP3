using StayManager.Core.Interfaces;

namespace StayManager.Core.Observer
{
    public class UserSubscriber : IReservaObserver
    {
        private readonly string _userName;

        public UserSubscriber(string userName)
        {
            _userName = userName;
        }

        public void Update(string message)
        {
            Console.WriteLine($"Notifying {_userName}: {message}");
        }
    }

}
