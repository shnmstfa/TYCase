using System;
using System.Collections.Generic;
using System.Text;

namespace TyCase.Model
{
    /// <summary>
    /// Enum of discount types
    /// </summary>
    public enum DiscountTypeEnum
    {
        Rate,
        Amount
    }
    /// <summary>
    /// Enum of discount config for determine discount apply calclulation
    /// </summary>
    public enum DiscountConfigEnum
    {
        Maximum,
        Minimum
    }
}
