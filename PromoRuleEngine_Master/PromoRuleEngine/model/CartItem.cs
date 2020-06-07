using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoRuleEngine_Master.model
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int TotalProduct { get; set; }
        public bool IsRuleApplied { get; set; }
    }
}
