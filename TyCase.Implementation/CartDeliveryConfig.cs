using System;
using System.Collections.Generic;
using System.Text;
using TyCase.Core;

namespace TyCase.Implementation
{
    /// <summary>
    /// Configuration of shopping cart delivery cost
    /// </summary>
    public class CartDeliveryConfig : IDeliveryCostConfig
    {
        public double _costPerDelivery;
        public double _costPerProduct;
        public double _fixedCost;
        /// <summary>
        /// Number of deliveries constant
        /// </summary>
        public double CostPerDelivery { get; }
        /// <summary>
        /// Number of products constant
        /// </summary>
        public double CostPerProduct { get; }
        /// <summary>
        /// Cost fix constant
        /// </summary>
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
