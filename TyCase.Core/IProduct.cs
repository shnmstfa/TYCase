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
        public ICategory Category { get; }
        public string Title { get; }
        public double Amount { get; }
    }
}
