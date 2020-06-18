﻿using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using TyCase.Core;
using TyCase.Model;

namespace TyCase.Implementation
{
    public class CategoryProductCountCampaign : ICampaign
    {
        private ICategory _category;
        private double _discountValue;
        private double _ruleFactor;
        private DiscountTypeEnum _discountType;
        private double _calculatedDiscountAmount;
        /// <summary>
        /// Campaign based on count of product in a category
        /// </summary>
        /// <param name="category">Category to apply discount</param>
        /// <param name="discountValue">Appyling value of discount</param>
        /// <param name="discountFactor">Comparing value to apply coupon</param>
        /// <param name="discountType">Apply type of discount</param>
        public CategoryProductCountCampaign(Category category, double discountValue, double discountFactor, DiscountTypeEnum discountType)
        {
            _category = category;
            _discountValue = discountValue;
            _ruleFactor = discountFactor;
            _discountType = discountType;
            if (!IsValid())
                throw new Exception("Campaign is not valid");
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
        /// Result of discount calculation
        /// </summary>
        public double CalculatedDiscountAmount { get { return _calculatedDiscountAmount; } }
        /// <summary>
        /// Category to apply discount
        /// </summary>
        public ICategory Category { get { return _category; } }
        /// <summary>
        /// Calculation metod of discount
        /// </summary>
        /// <param name="cartItems">Product of cart</param>
        /// <returns></returns>
        public double CalculateDiscount(IEnumerable<ICartItem> cartItems)
        {
            double count = 0;
            double totalAmount = 0;
            double discount = 0;
            if (cartItems != null)
            {

                foreach (var item in cartItems)
                {
                    //check if product category is sub category of discount category
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
                            discount = totalAmount > _discountValue ?  _discountValue : 0;
                            break;
                        default:
                            break;
                    }
                }
                _calculatedDiscountAmount = discount;
            }
            else
            {
                throw new Exception("Cart items can not be null");
            }
            return discount;
        }
        /// <summary>
        /// check if item is valid
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            return _category != null && _category.IsValid() && _discountValue > 0 && _ruleFactor > 0 && (_discountType == DiscountTypeEnum.Rate ? _discountValue <= 100 : true);
        }
    }
}
