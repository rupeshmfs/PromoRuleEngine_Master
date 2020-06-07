using PromoRuleEngine_Master.Interface;
using PromoRuleEngine_Master.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoRuleEngine_Master.PromoRule
{
    public class MixedItemPricePromoRule : ICalculatePromoPrice
    {
        private readonly int _itemPromoCount;
        private readonly decimal _itemPromoPrice;
        private readonly List<string> _lstProduct;

        public MixedItemPricePromoRule(List<string> lstProduct, int promoPrice, int productCount)
        {
            this._lstProduct = lstProduct;
            this._itemPromoPrice = promoPrice;
            this._itemPromoCount = productCount;
        }
        public decimal CalculatePromoPrice(ShoppingCart cart)
        {
            var listItems = cart.CartItems.Where(c => c.TotalProduct.Equals(this._itemPromoCount) && this._lstProduct.Any(l => c.Product.ID.Equals(l.ToString())));
            //var listItems = cart.CartItems.Where(c => c.TotalProduct >= this._itemPromoCount && this._lstProduct.Any(l => c.Product.ID.Equals(l.ToString())));
            decimal TotalItemPrice = 0.0m;

            if (listItems.Count() == this._lstProduct.Count)
            {
                TotalItemPrice += this._itemPromoPrice * this._itemPromoCount;
                foreach (var item in listItems)
                {
                    item.IsRuleApplied = true;

                //    int count = (item.TotalProduct - this._itemPromoCount) > 0 ? (item.TotalProduct - this._itemPromoCount) : 0;

                //    if (count > 0)
                //        cart.CartItems.Add(new CartItem { Product = item.Product, TotalProduct = count, IsRuleApplied = false });
                }                    
            }
            return TotalItemPrice;
        }
    }
}
