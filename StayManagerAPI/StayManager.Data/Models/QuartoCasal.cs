namespace StayManager.Data.Models
{
    public class QuartoCasal : QuartoModel
    {

        public override void AtribuirValores()
        {
            Preco = 100;

            decimal camaCasal = 150;

            Preco += camaCasal;
        }
    }
}
