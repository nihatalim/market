using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Requests.Company.Category
{
    public class UpdateCategoryRequest
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
    }
}
