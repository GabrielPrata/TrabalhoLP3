using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
