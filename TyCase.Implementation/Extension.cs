using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using TyCase.Core;

namespace TyCase.Implementation
{
    public static class Extensions
    {
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
