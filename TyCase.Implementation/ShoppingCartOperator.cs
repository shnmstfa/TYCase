using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TyCase.Core;
using TyCase.Implementation;
using TyCase.Model;

namespace TyCase.Implementation
{
    public class ShoppingCartOperator
    {
        private ICart _cart;
        /// <summary>
        /// Object to calculate outputs
        /// </summary>
        /// <param name="cart">Cart to calculate outputs</param>
        public ShoppingCartOperator(ICart cart)
        {
            _cart = cart;
        }
        /// <summary>
        /// Returns the total amounts of cart
        /// </summary>
        /// <returns></returns>
        public double GetTotalAmount()
        {
            return _cart.Products.Sum(x => x.Quantity * x.Product.Amount);
        }
        /// <summary>
        /// Returns the total amounts after apply discounts
        /// </summary>
        /// <returns></returns>
        public double GetTotalAmountAfterDiscount()
        {
            var totalAmount = GetTotalAmount();
            var discountAmount = _cart.AppliedCampaign.CalculateDiscount(_cart.Products);
            var couponAmount = _cart.AppliedCoupon.CalculateDiscount(_cart.Products);

            return totalAmount - discountAmount - couponAmount;
        }
        /// <summary>
        /// Returns the amount of coupon discount
        /// </summary>
        /// <returns></returns>
        public double GetCouponDiscounts()
        {
            return _cart.AppliedCoupon.CalculateDiscount(_cart.Products);
        }
        /// <summary>
        /// Returns the amount of applied campaign discount
        /// </summary>
        /// <returns></returns>
        public double GetCampaignDiscount()
        {
            return _cart.AppliedCampaign.CalculateDiscount(_cart.Products);
        }
        /// <summary>
        /// Returns the calculated delivery cost of cart
        /// </summary>
        /// <returns></returns>
        public double GetDeliveryCost()
        {
            return _cart.DeliveryCost;
        }
        /// <summary>
        /// Returns the category based product da
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public ProductCatReportModel GetProductsByCategory(Category category)
        {
            var categoryList = new List<string>();
            var result = new ProductCatReportModel()
            {
                Category = category
            };
            var products = new List<ShoppingCartItem>();
            ///Get products by parent category
            foreach (var item in _cart.Products)
            {
                if (item.Product.Category.Title == category.Title)
                {
                    products.Add((ShoppingCartItem)item);
                }
                else
                {
                    if (item.Product.Category.ParentCategory != null)
                    {
                        if (item.Product.Category.CheckCategoryTitleWithParent(category))
                        {
                            categoryList.Add(item.Product.Category.Title);
                        }
                    }
                }
            }
            products.AddRange(_cart.Products.Where(x => categoryList.Contains(x.Product.Category.Title)).Select(t => (ShoppingCartItem)t));
            result.Product = products;
            return result;
        }
        /// <summary>
        /// Returns dthe total discount amount (campaign and coupon)
        /// </summary>
        /// <returns></returns>
        public double GetTotalDiscount()
        {
            return GetCampaignDiscount() + GetCouponDiscounts(); 
        }
        /// <summary>
        /// Prints the cart total amount and delivery cost
        /// </summary>
        /// <returns></returns>
        public string print()
        {
            return string.Format("Total Amount:{0} - Delivery Cost:{1}", GetTotalAmountAfterDiscount().ToString(), GetDeliveryCost().ToString());
        }

    }
}
