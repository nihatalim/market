using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace market.api.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }
        public int? ParentID { get; set; }
        public virtual Category Parent { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
