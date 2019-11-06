using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Requests.Company.Product
{
    public class UpdateProductRequest : BaseCompanyRequest
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public decimal Price { get; set; }
        public decimal TaxRate { get; set; }
        public int? CategoryID { get; set; }
        public int ProductID { get; set; }
    }
}
