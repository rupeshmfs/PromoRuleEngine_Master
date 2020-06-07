using PromoRuleEngine_Master.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoRuleEngine_Master.Interface
{
    interface ICalculatePromoPrice
    {
        decimal CalculatePromoPrice(ShoppingCart cart);
    }
}
