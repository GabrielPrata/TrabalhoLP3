namespace StayManager.Data.Models
{
    public abstract class QuartoModel
    {
        public int Id { get; set; }
        public decimal Preco { get; set; }

        protected QuartoModel()
        {
        }

        public abstract void AtribuirValores();
    }


}
