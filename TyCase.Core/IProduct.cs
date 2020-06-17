using System;
using System.Collections.Generic;
using System.Text;

namespace TyCase.Core
{
    /// <summary>
    /// Product Model Interface For Shopping Cart
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// Category of product
        /// </summary>
        public ICategory Category { get; }
        /// <summary>
        /// Name of product
        /// </summary>
        public string Title { get; }
        /// <summary>
        /// Amount of product
        /// </summary>
        public double Amount { get; }
        public bool IsValid();
    }
}
