using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TyCase.Core;
using TyCase.Model;

namespace TyCase.Implementation
{
    /// <summary>
    /// Shopping cart object
    /// </summary>
    public class ShoppingCart : ICart
    {
        private List<ICartItem> _cartItems;
        private ICampaign _appliedDiscount;
        private ICampaign _appliedCoupon;
        private double _deliveryCost;
        private DiscountConfigEnum _discountConfig;
        /// <summary>
        /// Products of cart
        /// </summary>
        public IEnumerable<ICartItem> Products
        {
            get
            {
                return _cartItems.AsEnumerable();
            }
        }
        /// <summary>
        /// Numbers of deliveries based on distinct categories
        /// </summary>
        public double NumberOfDeliveries => calculateNumberOfDeliveries();
        /// <summary>
        /// Numbers of products(not quantity)
        /// </summary>
        public double NumberOfProducts => calculateNumberOfProducts();
        /// <summary>
        /// Applied campaign object based on campaign apply rule
        /// </summary>
        public ICampaign AppliedCampaign => _appliedDiscount;
        /// <summary>
        /// Applied coupon object
        /// </summary>
        public ICampaign AppliedCoupon => _appliedCoupon;
        /// <summary>
        /// Cost of delivery
        /// </summary>
        public double DeliveryCost => _deliveryCost;

        public ShoppingCart()
        {
            _cartItems = new List<ICartItem>();
            _discountConfig = DiscountConfigEnum.Maximum;
        }
        /// <summary>
        /// Add product to cart items with quantity
        /// </summary>
        /// <param name="product">Product of cart</param>
        /// <param name="quantity">Quantity of product in cart</param>
        public void AddItem(Product product, double quantity)
        {
            AddItem(new ShoppingCartItem()
            {
                Product = product,
                Quantity = quantity
            });
        }
        /// <summary>
        /// Calculate and apply delivery cost
        /// </summary>
        /// <param name="cost"></param>
        public void ApplyDeliveryCost(double cost)
        {
            _deliveryCost = cost;
        }
        /// <summary>
        /// Discount calculation configuration setter method
        /// </summary>
        /// <param name="config">Configuration of discount calculation</param>
        public void ChangeDiscountType(DiscountConfigEnum config)
        {
            _discountConfig = config;
        }
        /// <summary>
        /// Apply discounts to cart based on calculation rule of cart
        /// </summary>
        /// <param name="campaigns">Capaigns to appy to cart</param>
        public void ApplyDiscounts(params ICampaign[] campaigns)
        {
            this.ApplyDiscounts(_discountConfig, campaigns);
        }
        /// <summary>
        /// Apply coupon to cart
        /// </summary>
        /// <param name="coupon">Caoupon to appy to cart</param>
        public void ApplyCoupon(ICampaign coupon)
        {
            _appliedCoupon = coupon;
        }
        private void AddItem(ICartItem item)
        {
            var cartItem = _cartItems.FirstOrDefault(x => x.Product.Category.Title == item.Product.Category.Title && x.Product.Title == item.Product.Title && x.Product.Amount == item.Product.Amount);

            if (cartItem != null)
                cartItem.Quantity += item.Quantity;
            else
                _cartItems.Add(item);
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
        private double calculateNumberOfDeliveries()
        {
            var cartCategories = _cartItems.Select(x => x.Product.Category).Distinct();
            var masterCategories = cartCategories.Where(x => x.ParentCategory == null).Select(t => (Category)t);
            var otherCategories = cartCategories.Where(x => x.ParentCategory != null).Select(t => (Category)t);

            var distinctCategories = new List<Category>();
            distinctCategories.AddRange(masterCategories);
            //Check sub categories and if added parent to category pass them
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
