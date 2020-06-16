using System;
using System.Collections.Generic;
using System.Text;

namespace TyCase.Core
{
    public interface ICart
    {
        public IEnumerable<ICartItem> Products { get; }
        public ICampaign AppliedCampaign { get; }
        public ICampaign AppliedCoupon { get; }
        public double NumberOfDeliveries { get; }
        public double NumberOfProducts { get; }
        public double DeliveryCost { get; }
        public void ApplyDiscounts(params ICampaign[] campaigns);
        public void ApplyCoupon(ICampaign campaign);
    }
}
