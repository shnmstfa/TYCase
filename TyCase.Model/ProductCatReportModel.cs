using System;
using System.Collections.Generic;
using System.Text;
using TyCase.Core;

namespace TyCase.Model
{
    public class ProductCatReportModel
    {
        public List<ShoppingCartItem> Product { get; set; }
        public Category Category { get; set; }
    }
}
