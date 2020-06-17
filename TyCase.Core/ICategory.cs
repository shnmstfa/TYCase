using System;
using System.Collections.Generic;
using System.Text;

namespace TyCase.Core
{
    public interface ICategory
    {
        /// <summary>
        /// Title of category
        /// </summary>
        public string Title { get; }
        /// <summary>
        /// Parent category
        /// </summary>
        public ICategory ParentCategory { get; }
        public bool IsValid();
    }
}
