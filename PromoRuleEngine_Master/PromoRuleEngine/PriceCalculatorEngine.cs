using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoRuleEngine_Master.Interface;
using PromoRuleEngine_Master.model;

namespace PromoRuleEngine_Master
{
    public class PriceCalculatorEngine : ITotalPriceCalculator
    {
        List<ICalculatePromoPrice> _promotions;

        public PriceCalculatorEngine(List<ICalculatePromoPrice> promotions)
        {
            _promotions = promotions;
        }

        public decimal TotalPriceCalculation(ShoppingCart cart)
        {
            decimal totalPrice = 0.0m;

            foreach (var promoRule in _promotions)
            {
                totalPrice += promoRule.CalculatePromoPrice(cart);
            }

            foreach (CartItem c in cart.CartItems)
            {
                if (!c.IsRuleApplied)
                    totalPrice += (c.Product.Price * c.TotalProduct);
            }
            return totalPrice;
        }
    }
}
