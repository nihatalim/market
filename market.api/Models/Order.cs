using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace market.api.Models
{
    public class Order : BaseEntity
    {
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }
        public int? ClientID { get; set; }
        public virtual Client Client { get; set; }
        public OrderType Type { get; set; }
        public decimal DiscountRate { get; set; }
        public bool IsActive { get; set; }
        public bool IsConfirmed { get; set; }
        public virtual ICollection<OrderProduct> Products { get; set; }
        public virtual decimal TotalTax => Products == null ? Decimal.Zero :
            Products.Sum(a => a.TaxPrice);
        public virtual decimal TotalDiscount => Products == null ? Decimal.Zero :
            Products.Sum(a => a.DiscountPrice);
        public virtual decimal TotalPrice => Products == null ? Decimal.Zero :
            Products.Sum(a => a.TotalPrice);
    }

    public enum OrderType
    {
        IN = 0,
        OUT = 1
    }
}
