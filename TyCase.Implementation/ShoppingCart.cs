using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TyCase.Core;
using TyCase.Model;

namespace TyCase.Implementation
{
    public class ShoppingCart : ICart
    {
        private List<ICartItem> _cartItems;
        private ICampaign _appliedDiscount;
        private ICampaign _appliedCoupon;
        private double _deliveryCost;
        private DiscountConfigEnum _discountConfig;

        public IEnumerable<ICartItem> Products
        {
            get
            {
                return _cartItems.AsEnumerable();
            }
        }

        public double NumberOfDeliveries => calculateNumberOfDeliveries();

        public double NumberOfProducts => calculateNumberOfProducts();
        public ICampaign AppliedCampaign => _appliedDiscount;
        public ICampaign AppliedCoupon => _appliedCoupon;
        public double DeliveryCost => _deliveryCost;

        public ShoppingCart()
        {
            _cartItems = new List<ICartItem>();
            _discountConfig = DiscountConfigEnum.Maximum;
        }

        public void AddItem(Product product, double quantity)
        {
            AddItem(new ShoppingCartItem()
            {
                Product = product,
                Quantity = quantity
            });
        }
        public void ApplyDeliveryCost(double cost)
        {
            _deliveryCost = cost;
        }
        private void AddItem(ICartItem item)
        {
            var cartItem = _cartItems.FirstOrDefault(x => x.Product.Category.Title == item.Product.Category.Title && x.Product.Title == item.Product.Title && x.Product.Amount == item.Product.Amount);

            if (cartItem != null)
                cartItem.Quantity += item.Quantity;
            else
                _cartItems.Add(item);
        }
        public void ChangeDiscountType(DiscountConfigEnum config)
        {
            _discountConfig = config;
        }
        public void ApplyDiscounts(params ICampaign[] campaigns)
        {
            this.ApplyDiscounts(_discountConfig, campaigns);
        }
        private void ApplyDiscounts(DiscountConfigEnum config, params ICampaign[] campaigns)
        {
            switch (config)
            {
                case DiscountConfigEnum.Maximum:
                    _appliedDiscount = getMaximumDiscount(campaigns);
                    break;
                case DiscountConfigEnum.Minimum:
                    _appliedDiscount = getMinimumDiscount(campaigns);
                    break;
                default:
                    break;
            }
        }
        private ICampaign getMaximumDiscount(params ICampaign[] campaigns)
        {
            return campaigns.OrderByDescending(x => x.CalculateDiscount(_cartItems)).FirstOrDefault();
        }
        private ICampaign getMinimumDiscount(params ICampaign[] campaigns)
        {
            return campaigns.OrderBy(x => x.CalculateDiscount(_cartItems)).FirstOrDefault();
        }

        public void ApplyCoupon(ICampaign coupon)
        {
            _appliedCoupon = coupon;
        }
        private double calculateNumberOfDeliveries()
        {
            var cartCategories = _cartItems.Select(x => x.Product.Category).Distinct();
            var masterCategories = cartCategories.Where(x => x.ParentCategory == null).Select(t => (Category)t);
            var otherCategories = cartCategories.Where(x => x.ParentCategory != null).Select(t => (Category)t);

            var distinctCategories = new List<Category>();
            distinctCategories.AddRange(masterCategories);
            foreach (var catCheck in otherCategories)
            {
                foreach (var item in masterCategories)
                {
                    if (catCheck.CheckCategoryTitleWithParent(item))
                    {
                        break;
                    }
                    else
                    {
                        distinctCategories.Add(catCheck);
                    }
                }
            }

            return distinctCategories.Count;
        }
        private double calculateNumberOfProducts()
        {
            return _cartItems.Select(x => x.Product).Distinct().Count();
        }
    }
}
