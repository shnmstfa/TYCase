using System;
using System.Collections.Generic;
using System.Text;
using TyCase.Core;

namespace TyCase.Model
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
