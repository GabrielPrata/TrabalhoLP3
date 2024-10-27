using StayManager.Data.Models;

namespace StayManager.Core.FactoryMethod
{
    public static class QuartoFactory
    {
        public static QuartoModel GetQuarto(string tipo)
        {
            switch (tipo.ToLower())
            {
                case "standart":
                    return new QuartoStandart();
                case "casal":
                    return new QuartoCasal();
                case "deluxe":
                    return new QuartoDeluxe();
                case "presidencial":
                    return new QuartoPresidencial();
                default:
                    throw new ArgumentException("Tipo de quarto inválido");
            }
        }
    }
}
