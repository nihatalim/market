using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Requests.Company.Category
{
    public class DeleteCategoryRequest : BaseCompanyRequest
    {
        public int CategoryID { get; set; }
    }
}
