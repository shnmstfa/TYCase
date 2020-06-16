using System;
using System.Collections.Generic;
using System.Text;

namespace TyCase.Core
{
    /// <summary>
    /// Interface of Cart Object
    /// </summary>
    public interface ICart
    {
        /// <summary>
        /// Items Of Cart Object
        /// </summary>
        public IEnumerable<ICartItem> Products { get; }
        /// <summary>
        /// Campaing object which applied to Cart
        /// </summary>
        public ICampaign AppliedCampaign { get; }
        /// <summary>
        /// Coupon object whic applied to Cart
        /// </summary>
        public ICampaign AppliedCoupon { get; }
        /// <summary>
        /// Number of distinct categories in the cart
        /// </summary>
        public double NumberOfDeliveries { get; }
        /// <summary>
        /// Number of different products in the cart. It is not the quantity of products
        /// </summary>
        public double NumberOfProducts { get; }
        /// <summary>
        /// Calculation result of delivery cost
        /// </summary>
        public double DeliveryCost { get; }
        /// <summary>
        /// Applying discounts to cart
        /// </summary>
        /// <param name="campaigns">Add campaigns to cart</param>
        public void ApplyDiscounts(params ICampaign[] campaigns);
        /// <summary>
        /// Applying coupon to cart
        /// </summary>
        /// <param name="campaigns">Add coupon to cart</param>
        public void ApplyCoupon(ICampaign campaign);
    }
}
