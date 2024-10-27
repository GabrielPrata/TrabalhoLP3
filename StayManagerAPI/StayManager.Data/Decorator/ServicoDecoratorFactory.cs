using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayManager.Data.Decorator
{

    public static class ServicoDecoratorFactory
    {
        public static decimal AplicarServicos(IReserva reserva, string servicos, decimal total)
        {
            var nomesServicos = servicos.Split(',').Select(s => s.Trim());

            foreach (var nomeServico in nomesServicos)
            {
                reserva = AplicarServico(reserva, nomeServico);
                total += reserva.CalculaValorTotal();
            }

            return total;
        }

        private static IReserva AplicarServico(IReserva reserva, string nomeServico)
        {
            switch (nomeServico)
            {
                case "TransporteAeroporto":
                    return new TransporteAeroporto(reserva);
                case "CafeManha":
                    return new CafeDaManha(reserva);
                default:
                    throw new ArgumentException($"Serviço não reconhecido: {nomeServico}");
            }
        }
    }
}
