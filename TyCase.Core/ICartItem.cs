using System;
using System.Collections.Generic;
using System.Text;

namespace TyCase.Core
{
    public interface ICartItem
    {
        /// <summary>
        /// Product of Cart
        /// </summary>
        public IProduct Product { get; set; }
        /// <summary>
        /// Quantity of Cart Item Product
        /// </summary>
        public  double Quantity{ get; set; }
    }
}
