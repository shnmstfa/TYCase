using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using TyCase.Core;

namespace TyCase.Implementation
{
    public static class Extensions
    {
        /// <summary>
        /// Compare this with another category to check parameter is parent of this
        /// </summary>
        /// <param name="category">This category</param>
        /// <param name="check">Category to compare</param>
        /// <returns></returns>
        public static bool CheckCategoryTitleWithParent(this ICategory category, ICategory check)
        {
            var result = false;

            if (category.Title == check.Title)
            {
                result = true;
            }
            else
            {
                if (category.ParentCategory != null)
                {
                    result = category.ParentCategory.CheckCategoryTitleWithParent(check);
                }
            }

            return result;
        }
    }
}
