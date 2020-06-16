using System;
using System.Collections.Generic;
using System.Text;
using TyCase.Core;

namespace TyCase.Model
{
    public class Category : ICategory
    {
        private string _title;
        private ICategory _parentCategory;
        
        public Category(string title)
        {
            _title = title;
        }

        public Category(string title, Category parentCategory)
        {
            _title = title;
            _parentCategory = parentCategory;
        }

        public ICategory ParentCategory
        {
            get
            {
                return _parentCategory;
            }
        }
        public string Title
        {
            get
            {
                return _title;
            }
        }

        public double DiscountAmount { get; set; }
    }
}
