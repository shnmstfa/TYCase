using System;
using System.Collections.Generic;
using System.Text;

namespace TyCase.Core
{
    /// <summary>
    /// Interface of delivery cost calculartors
    /// </summary>
    public interface IDeliveryCostConfig
    {
        /// <summary>
        /// Calculates the delivery cost of cart
        /// </summary>
        /// <param name="cart">Shopping cart for calculate delivery cost</param>
        /// <returns></returns>
        public double CalculateFor(ICart cart);
    }
}
