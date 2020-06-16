using System;
using System.Collections.Generic;
using System.Text;

namespace TyCase.Core
{
    public interface ICartItem
    {
        public IProduct Product { get; set; }
        public  double Quantity{ get; set; }
    }
}
