using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace TyCase.Core
{
    /// <summary>
    ///     Interface of Campaign
    /// </summary>
    public interface ICampaign
    {
        /// <summary>
        /// Value of Discount to appyl (ex. %10) 
        /// </summary>
        public double DiscountValue { get; }
        /// <summary>
        /// Comparing value to apply DiscountValue (ex. Product count)
        /// </summary>
        public double RuleFactor { get; }
        /// <summary>
        ///     Calculates the discount by given cartItems
        /// </summary>
        /// <param name="cartItems">Items of cart(ex. Products of Carts)</param>
        /// <returns></returns>
        public double CalculateDiscount(IEnumerable<ICartItem> cartItems);
    }
}
