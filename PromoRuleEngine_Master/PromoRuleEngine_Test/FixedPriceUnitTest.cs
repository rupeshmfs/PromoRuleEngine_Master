using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromoRuleEngine_Master;
using PromoRuleEngine_Master.Interface;
using PromoRuleEngine_Master.model;
using PromoRuleEngine_Master.PromoRule;

namespace PromoRuleEngine_Test
{
    [TestClass]
    public class FixedPriceUnitTest
    {
        private ITotalPriceCalculator _priceCalculator;

        public FixedPriceUnitTest()
        {
            List<ICalculatePromoPrice> _promoRules = new List<ICalculatePromoPrice>();

            _promoRules.Add(new FixedPricePromoRule("A", 3, 130));
            _promoRules.Add(new FixedPricePromoRule("B", 2, 45));
            _priceCalculator = new PriceCalculatorEngine(_promoRules);
        }

        [TestMethod]
        public void ItemFixedPricePromotionRuleTest()
        {
            ShoppingCart shopingCart = new ShoppingCart();
            List<CartItem> cartItems = new List<CartItem>();

            cartItems.Add(new CartItem() { TotalProduct = 1, Product = new Product() { ID = "A", Price = 50 } });
            cartItems.Add(new CartItem() { TotalProduct = 1, Product = new Product() { ID = "B", Price = 30 } });
            cartItems.Add(new CartItem() { TotalProduct = 1, Product = new Product() { ID = "C", Price = 20 } });
            shopingCart.CartItems = cartItems;

            decimal TotalPrice = _priceCalculator.TotalPriceCalculation(shopingCart);

            Assert.AreEqual(100.00m, TotalPrice);
        }

        [TestMethod]
        public void ItemFixedPricePromotionRuleTest2()
        {
            ShoppingCart shopingCart = new ShoppingCart();
            List<CartItem> cartItems = new List<CartItem>();

            cartItems.Add(new CartItem() { TotalProduct = 5, Product = new Product() { ID = "A", Price = 50 } });
            cartItems.Add(new CartItem() { TotalProduct = 5, Product = new Product() { ID = "B", Price = 30 } });
            cartItems.Add(new CartItem() { TotalProduct = 1, Product = new Product() { ID = "C", Price = 20 } });
            shopingCart.CartItems = cartItems;

            decimal TotalPrice = _priceCalculator.TotalPriceCalculation(shopingCart);

            Assert.AreEqual(370.00m, TotalPrice);
        }
    }
}
