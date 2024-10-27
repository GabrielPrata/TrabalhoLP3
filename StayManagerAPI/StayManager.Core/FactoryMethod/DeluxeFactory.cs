using StayManager.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayManager.Data.Models.FactoryMethodModels
{
    internal class DeluxeFactory : IQuartoFactory
    {
        public QuartoModel CriarQuarto()
        {
            return new QuartoDeluxe();
        }
    }
}
