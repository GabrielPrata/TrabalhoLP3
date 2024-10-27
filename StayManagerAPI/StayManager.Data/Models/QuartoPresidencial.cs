namespace StayManager.Data.Models
{
    public class QuartoPresidencial : QuartoModel
    {
        public override void AtribuirValores()
        {
            Preco = 100;


            decimal camaCasal = 150;
            decimal arCondicionado = 75;
            decimal hidromassagem = 150;

            Preco += camaCasal + arCondicionado + hidromassagem;
        }
    }
}
