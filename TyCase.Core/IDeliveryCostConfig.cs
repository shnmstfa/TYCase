using System;
using System.Collections.Generic;
using System.Text;

namespace TyCase.Core
{
    public interface IDeliveryCostConfig
    {
        public double CalculateFor(ICart cart);
    }
}
