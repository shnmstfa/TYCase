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
        /// <summary>
        /// Category of products
        /// </summary>
        /// <param name="title">Name of category</param>
        public Category(string title)
        {
            _title = title;
            if (!IsValid())
                throw new Exception("Category not valid");
        }
        /// <summary>
        /// Category of products
        /// </summary>
        /// <param name="title">Name of category</param>
        /// <param name="parentCategory">Parent of category</param>
        public Category(string title, Category parentCategory)
        {
            _title = title;
            _parentCategory = parentCategory;
            if (!_parentCategory.IsValid() || !IsValid())
                throw new Exception("Category not valid");
        }
        /// <summary>
        /// Parent of category
        /// </summary>
        public ICategory ParentCategory
        {
            get
            {
                return _parentCategory;
            }
        }
        /// <summary>
        /// Name of category
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }
        }
        public bool IsValid()
        {
            return !string.IsNullOrEmpty(_title);
        }
    }
}
