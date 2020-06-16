using System;
using System.Collections.Generic;
using System.Text;
using TyCase.Core;

namespace TyCase.Implementation
{
    public class CartDeliveryConfig : IDeliveryCostConfig
    {
        public double _costPerDelivery;
        public double _costPerProduct;
        public double _fixedCost;

        public double CostPerDelivery { get; }
        public double CostPerProduct { get; }
        public double FixedCost { get; }

        public CartDeliveryConfig(double costPerDelivery, double costPerProduct, double fixedCost)
        {
            _costPerDelivery = costPerDelivery;
            _costPerProduct = costPerProduct;
            _fixedCost = fixedCost;
        }

        public double CalculateFor(ICart cart)
        {
            return (_costPerDelivery * cart.NumberOfDeliveries) + (_costPerProduct * cart.NumberOfProducts) + _fixedCost;
        }
    }
}
