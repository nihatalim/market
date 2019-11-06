using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Requests.Company.Category
{
    public class CreateCategoryRequest : BaseCompanyRequest
    {
        public string Name { get; set; }
    }
}
