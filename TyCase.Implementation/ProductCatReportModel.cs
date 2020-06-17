using System;
using System.Collections.Generic;
using TyCase.Model;

namespace TyCase.Implementation
{
    /// <summary>
    /// Reporting model for print result
    /// </summary>
    public class ProductCatReportModel
    {
        /// <summary>
        /// Products of category
        /// </summary>
        public List<ShoppingCartItem> Product { get; set; }
        /// <summary>
        /// Category for group products
        /// </summary>
        public Category Category { get; set; }
    }
}
