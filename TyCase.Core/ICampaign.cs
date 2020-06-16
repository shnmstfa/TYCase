using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace TyCase.Core
{
    public interface ICampaign
    {
        public double DiscountValue { get; }
        public double RuleFactor { get; }
        public double CalculateDiscount(IEnumerable<ICartItem> cartItems);
    }
}
