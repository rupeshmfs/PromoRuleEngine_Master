using PromoRuleEngine_Master;
using PromoRuleEngine_Master.Interface;
using PromoRuleEngine_Master.PromoRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoRuleEngine_Test
{
    class MixedItemPriceUnitTest
    {
        private ITotalPriceCalculator _priceCalculator;

        public MixedItemPriceUnitTest()
        {
            List<ICalculatePromoPrice> _promoRules = new List<ICalculatePromoPrice>();

            _promoRules.Add(new FixedPricePromoRule("A", 3, 130));
            _promoRules.Add(new FixedPricePromoRule("B", 2, 45));
            _promoRules.Add(new MixedItemPricePromoRule(new List<string> { "C", "D" }, 30, 2));
            _priceCalculator = new PriceCalculatorEngine(_promoRules);
        }
    }
}
