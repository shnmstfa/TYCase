using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using TyCase.Core;
using TyCase.Model;

namespace TyCase.Implementation
{
    public class CategoryProductCountCampaign : ICampaign
    {
        private double _discountAmount;
        private ICategory _category;
        private double _discountValue;
        private double _ruleFactor;
        private DiscountTypeEnum _discountType;
        private double _calculatedDiscountAmount ;
        public CategoryProductCountCampaign(Category category, double discountValue, double discountFactor, DiscountTypeEnum discountType)
        {
            _category = category;
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
        public double DiscountAmount { get { return _discountAmount; } }
        public double CalculatedDiscountAmount { get { return _calculatedDiscountAmount; } }
        public ICategory Category { get { return _category; } }
        public double CalculateDiscount(IEnumerable<ICartItem> cartItems)
        {
            double count = 0;
            double totalAmount = 0;
            double discount = 0;
            foreach (var item in cartItems)
            {
                if (item.Product.Category.CheckCategoryTitleWithParent(_category))
                {
                    count += item.Quantity;
                    totalAmount += item.Product.Amount * item.Quantity;
                }
            }

            if (count >= _ruleFactor)
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
            _calculatedDiscountAmount = discount;
            return discount;
        }
    }
}
