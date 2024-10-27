namespace StayManager.Data.Models
{
    public class QuartoDeluxe : QuartoModel
    {
        public override void AtribuirValores()
        {
            Preco = 100;
            decimal camaCasal = 150;
            decimal arCondicionado = 75;

            Preco += camaCasal + arCondicionado;
        }
    }
}
