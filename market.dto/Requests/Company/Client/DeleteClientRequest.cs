using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Requests.Company.Client
{
    public class DeleteClientRequest : BaseCompanyRequest
    {
        public int ClientID { get; set; }
    }
}
