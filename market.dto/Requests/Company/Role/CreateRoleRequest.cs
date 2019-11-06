using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Requests.Company.Role
{
    public class CreateRoleRequest : BaseCompanyRequest
    {
        public string Name { get; set; }
    }
}
