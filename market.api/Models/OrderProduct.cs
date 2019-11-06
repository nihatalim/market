using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace market.api.Models
{
    public class OrderProduct : BaseEntity
    {
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal TaxRate { get; set; }
        public decimal DiscountRate { get; set; }
        public virtual decimal TaxPrice => Decimal.Multiply(Count, Decimal.Multiply(Price, Decimal.Divide(TaxRate, 100)));
        public virtual decimal DiscountPrice => Decimal.Multiply(Count, Decimal.Multiply(Price, Decimal.Divide(DiscountRate, 100)));
        public virtual decimal TotalPrice => Decimal.Subtract(Decimal.Add(Price, TaxPrice), DiscountPrice);
    }
}
