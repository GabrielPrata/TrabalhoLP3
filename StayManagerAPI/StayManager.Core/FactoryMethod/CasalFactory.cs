using StayManager.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
