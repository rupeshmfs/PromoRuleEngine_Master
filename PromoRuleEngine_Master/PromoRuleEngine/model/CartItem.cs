using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoRuleEngine_Master.model
{
    public class CartItem
    {
        public Product Item { get; set; }
        public int TotalItem { get; set; }
        public bool IsRuleApplied { get; set; }
    }
}
