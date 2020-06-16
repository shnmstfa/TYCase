using System;
using System.Collections.Generic;
using System.Text;

namespace TyCase.Core
{
    public interface ICategory
    {
        public string Title { get; }
        public ICategory ParentCategory { get; }
        public double DiscountAmount { get; set; }
    }
}
