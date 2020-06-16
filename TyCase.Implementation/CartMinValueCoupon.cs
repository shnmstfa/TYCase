using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TyCase.Core;
using TyCase.Model;

namespace TyCase.Implementation
{
    public class CartMinValueCoupon : ICampaign
    {
        private double _discountValue;
        private double _ruleFactor;
        private DiscountTypeEnum _discountType;
        public CartMinValueCoupon(double discountFactor, double discountValue,  DiscountTypeEnum discountType)
        {
            _discountValue = discountValue;
            _ruleFactor = discountFactor;
            _discountType = discountType;
        }
        public double DiscountValue
        {
            get
            {
                return _discountValue;
            }
        }
        public double RuleFactor
        {
            get
            {
                return _ruleFactor;
            }
        }
        public DiscountTypeEnum DiscountType
        {
            get
            {
                return _discountType;
            }
        }

        public double CalculateDiscount(IEnumerable<ICartItem> cartItems)
        {
            double discount = 0;
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

            return discount;
        }
    }
}
