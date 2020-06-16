using System;
using System.Collections.Generic;
using System.Text;
using TyCase.Core;

namespace TyCase.Model
{
    public class ShoppingCartItem : ICartItem
    {
        public IProduct Product { get; set; }
        public double Quantity { get ; set ; }
    }
}
