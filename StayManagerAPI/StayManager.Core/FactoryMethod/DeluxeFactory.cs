using StayManager.Core.Interfaces;

namespace StayManager.Data.Models.FactoryMethodModels
{
    internal class DeluxeFactory : IQuartoFactory
    {
        public QuartoModel CriarQuarto()
        {
            return new QuartoDeluxe();
        }
    }
}
