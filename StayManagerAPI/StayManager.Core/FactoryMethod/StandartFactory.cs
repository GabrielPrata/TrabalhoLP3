using StayManager.Core.Interfaces;

namespace StayManager.Data.Models.FactoryMethodModels
{
    internal class StandartFactory : IQuartoFactory
    {
        public QuartoModel CriarQuarto()
        {
            return new QuartoStandart();
        }
    }
}
