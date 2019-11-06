using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Requests.Company.Client
{
    public class CreateClientRequest : BaseCompanyRequest
    {
        public string Name { get; set; }
        public int Number { get; set; }
    }
}
