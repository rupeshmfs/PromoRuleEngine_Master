using PromoRuleEngine_Master.Interface;
using PromoRuleEngine_Master.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoRuleEngine_Master.PromoRule
{
    class MixedItemPricePromoRule : ICalculatePromoPrice
    {
        public decimal CalculatePromoPrice(ShoppingCart cart)
        {
            return 0.0m;
        }
    }
}
