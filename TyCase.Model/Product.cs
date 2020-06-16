using System;
using TyCase.Core;

namespace TyCase.Model
{
    public class Product : IProduct
    {
        private string _title;
        private double _amount;
        private ICategory _category;
        /// <summary>
        /// Product of shopping cart
        /// </summary>
        /// <param name="title">Name of product</param>
        /// <param name="amount">Amount of product</param>
        /// <param name="category">Category of product</param>
        public Product(string title, double amount, Category category)
        {
            _title = title;
            _amount = amount;
            _category = category;
        }
        /// <summary>
        /// Category of product
        /// </summary>
        public ICategory Category
        {
            get
            {
                return _category;
            }
        }
        /// <summary>
        /// Name of product
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }
        }
        /// <summary>
        /// Amount of product
        /// </summary>
        public double Amount
        {
            get
            {
                return _amount;
            }
        }
    }
}
