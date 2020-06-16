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
        public ShoppingCartOperator(ICart cart)
        {
            _cart = cart;
        }

        public double GetTotalAmount()
        {
            return _cart.Products.Sum(x => x.Quantity * x.Product.Amount);
        }
        public double GetTotalAmountAfterDiscount()
        {
            var totalAmount = GetTotalAmount();
            var discountAmount = _cart.AppliedCampaign.CalculateDiscount(_cart.Products);
            var couponAmount = _cart.AppliedCoupon.CalculateDiscount(_cart.Products);

            return totalAmount - discountAmount - couponAmount;
        }
        public double GetCouponDiscounts()
        {
            return _cart.AppliedCoupon.CalculateDiscount(_cart.Products);
        }
        public double GetCampaignDiscount()
        {
            return _cart.AppliedCampaign.CalculateDiscount(_cart.Products);
        }
        public double GetDeliveryCost()
        {
            return _cart.DeliveryCost;
        }

        public ProductCatReportModel GetProductsByCategory(Category category)
        {
            var categoryList = new List<string>();
            var result = new ProductCatReportModel()
            {
                Category = category
            };
            var products = new List<ShoppingCartItem>();
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
        public double GetTotalDiscount()
        {
            return GetCampaignDiscount() + GetCouponDiscounts(); 
        }

    }
}
