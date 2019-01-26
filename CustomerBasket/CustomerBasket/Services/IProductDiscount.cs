using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerBasket.Services
{
    public interface IProductDiscount
    {
        decimal ApplyDiscount(Basket basket);
    }
}
