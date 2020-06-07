using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoRuleEngine_Master.model
{
    public class ShoppingCart
    {
        public IEnumerable<CartItem> CartItems { get; set; }
        public Decimal TotalPrice { get; set; }
    }
}
