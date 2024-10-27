using StayManager.Core.Interfaces;

namespace StayManager.Data.Models.FactoryMethodModels
{
    internal class PresidencialFactory : IQuartoFactory
    {
        public QuartoModel CriarQuarto()
        {
            return new QuartoPresidencial();
        }
    }
}
