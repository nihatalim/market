using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Models
{
    public class Category : BaseDTO
    {
        public string Name { get; set; }
        public int CompanyID { get; set; }
        public Company Company { get; set; }
        public int? ParentID { get; set; }
        public Category Parent { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
