using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromoRuleEngine_Master;
using PromoRuleEngine_Master.Interface;
using PromoRuleEngine_Master.model;
using PromoRuleEngine_Master.PromoRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoRuleEngine_Test
{
    [TestClass]
    public class MixedItemPriceUnitTest
    {
        private ITotalPriceCalculator _priceCalculator;

        public MixedItemPriceUnitTest()
        {
            List<ICalculatePromoPrice> _promoRules = new List<ICalculatePromoPrice>();

            _promoRules.Add(new FixedPricePromoRule("A", 3, 130));
            _promoRules.Add(new FixedPricePromoRule("B", 2, 45));
            _promoRules.Add(new MixedItemPricePromoRule(new List<string> { "C", "D" }, 30, 1));
            _priceCalculator = new PriceCalculatorEngine(_promoRules);
        }

        [TestMethod]
        public void MixedItemPromoPriceUnitTest()
        {
            ShoppingCart shopingCart = new ShoppingCart();
            List<CartItem> cartItems = new List<CartItem>();

            cartItems.Add(new CartItem() { TotalProduct = 3, Product = new Product() { ID = "A", Price = 50 } });
            cartItems.Add(new CartItem() { TotalProduct = 5, Product = new Product() { ID = "B", Price = 30 } });
            cartItems.Add(new CartItem() { TotalProduct = 1, Product = new Product() { ID = "C", Price = 20 } });
            cartItems.Add(new CartItem() { TotalProduct = 1, Product = new Product() { ID = "D", Price = 15 } });
            shopingCart.CartItems = cartItems;

            decimal TotalPrice = _priceCalculator.TotalPriceCalculation(shopingCart);

            Assert.AreEqual(280.00m, TotalPrice);
        }
             
    }
}
