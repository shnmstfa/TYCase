using System;
using TyCase.Core;

namespace TyCase.Model
{
    public class Product : IProduct
    {
        private string _title;
        private double _amount;
        private ICategory _category;
        public Product(string title, double amount, Category category)
        {
            _title = title;
            _amount = amount;
            _category = category;
        }

        public ICategory Category
        {
            get
            {
                return _category;
            }
        }
        public string Title
        {
            get
            {
                return _title;
            }
        }
        public double Amount
        {
            get
            {
                return _amount;
            }
        }
    }
}
