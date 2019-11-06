using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Requests.Company.Client
{
    public class UpdateClientRequest : BaseCompanyRequest
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
    }
}
