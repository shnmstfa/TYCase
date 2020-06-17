using System;
using System.Collections.Generic;
using System.Text;
using TyCase.Core;

namespace TyCase.Implementation
{
    /// <summary>
    /// Cart item definition for shopping cart
    /// </summary>
    public class ShoppingCartItem : ICartItem
    {
        public IProduct _product;
        public double _quantity { get; set; }
        /// <summary>
        /// Create a shopping cart item
        /// </summary>
        public ShoppingCartItem(IProduct product, double quantity)
        {
            _product = product;
            _quantity = quantity;
            if (!IsValid())
            {
                throw new Exception("Product Item not valid");
            }
        }
        /// <summary>
        /// Product of shopping cart
        /// </summary>
        public IProduct Product { get { return _product; } }
        /// <summary>
        /// Quantity of products
        /// </summary>
        public double Quantity { get { return _quantity; } }
        /// <summary>
        /// check the item is valid
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            return _product != null && _product.IsValid() && _quantity > 0;
        }
        /// <summary>
        /// Increase the quantity of item
        /// </summary>
        /// <param name="val">value of increment</param>
        public void IncreaseQuantity(double val)
        {
            if (val > 0)
                _quantity += val;
        }
    }
}
