using PromoRuleEngine_Master.Interface;
using PromoRuleEngine_Master.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoRuleEngine_Master.PromoRule
{
   public class FixedPricePromoRule : ICalculatePromoPrice
    {
        private readonly int _itemCount;
        private readonly decimal _itemPromoPrice;
        private readonly string _itemType;

        public FixedPricePromoRule(string itemType, int itemCount, decimal itemPromoPrice)
        {
            this._itemType = itemType;
            this._itemCount = itemCount;
            this._itemPromoPrice = itemPromoPrice;
        }

        public decimal CalculatePromoPrice(ShoppingCart cart)
        {
            var cartItem = cart.CartItems.FirstOrDefault(x => x.Product.ID.Equals(this._itemType));
            decimal TotalItemPrice = 0.0m;

            if (cartItem != null)
            {
                int index = 1;
                int remainder = cartItem.TotalProduct % this._itemCount;
                index = cartItem.TotalProduct / this._itemCount;
                TotalItemPrice = (index > 0) ? ((remainder > 0) ? ((_itemPromoPrice * index) + remainder * cartItem.Product.Price) : _itemPromoPrice * index) : (cartItem.TotalProduct * cartItem.Product.Price);
                cartItem.IsRuleApplied = true;
            }
            return TotalItemPrice;
        }
    }
}
