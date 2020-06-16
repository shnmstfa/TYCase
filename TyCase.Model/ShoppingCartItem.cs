using System;
using System.Collections.Generic;
using System.Text;
using TyCase.Core;

namespace TyCase.Model
{
    /// <summary>
    /// Cart item definition for shopping cart
    /// </summary>
    public class ShoppingCartItem : ICartItem
    {
        /// <summary>
        /// Product of shopping cart
        /// </summary>
        public IProduct Product { get; set; }
        /// <summary>
        /// Quantity of products
        /// </summary>
        public double Quantity { get ; set ; }
    }
}
