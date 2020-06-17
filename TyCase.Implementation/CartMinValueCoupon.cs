using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TyCase.Core;
using TyCase.Model;

namespace TyCase.Implementation
{
    /// <summary>
    /// Coupon implementation based on min value of Cart
    /// </summary>
    public class CartMinValueCoupon : ICampaign
    {
        private double _discountValue;
        private double _ruleFactor;
        private DiscountTypeEnum _discountType;
        /// <summary>
        /// Coupon implementation based on min value of Cart
        /// </summary>
        /// <param name="discountFactor">Comparing value to apply coupon</param>
        /// <param name="discountValue">Appyling value of discount</param>
        /// <param name="discountType">Apply type of discount</param>
        public CartMinValueCoupon(double discountFactor, double discountValue,  DiscountTypeEnum discountType)
        {
            _discountValue = discountValue;
            _ruleFactor = discountFactor;
            _discountType = discountType;
            if (!IsValid())
                throw new System.Exception("Campaign is not valid");
        }
        /// <summary>
        /// Appyling value of discount
        /// </summary>
        public double DiscountValue
        {
            get
            {
                return _discountValue;
            }
        }
        /// <summary>
        /// Comparing value to apply coupon
        /// </summary>
        public double RuleFactor
        {
            get
            {
                return _ruleFactor;
            }
        }
        /// <summary>
        /// Apply type of discount
        /// </summary>
        public DiscountTypeEnum DiscountType
        {
            get
            {
                return _discountType;
            }
        }
        /// <summary>
        /// Calculates the discount value
        /// </summary>
        /// <param name="cartItems">Products of cart</param>
        /// <returns></returns>
        public double CalculateDiscount(IEnumerable<ICartItem> cartItems)
        {
            
            double discount = 0;
            if (cartItems != null)
            {
                var totalAmount = cartItems.Sum(x => x.Quantity * x.Product.Amount);
                if (totalAmount >= _ruleFactor)
                {
                    switch (_discountType)
                    {
                        case DiscountTypeEnum.Rate:
                            discount = totalAmount * (_discountValue / 100);
                            break;
                        case DiscountTypeEnum.Amount:
                            discount = _discountValue;
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                throw new System.Exception("cartItems can not be null");
            }

            return discount;
        }
        /// <summary>
        /// check if item is valid
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            return _discountValue > 0 && _ruleFactor > 0;
        }
    }
}
