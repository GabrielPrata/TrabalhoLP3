using StayManager.Core.Interfaces;

namespace StayManager.Data.Models.FactoryMethodModels
{
    public class CasalFactory : IQuartoFactory
    {
        public QuartoModel CriarQuarto()
        {
            return new QuartoCasal();
        }
    }
}
