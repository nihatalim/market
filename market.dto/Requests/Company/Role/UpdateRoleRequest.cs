using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Requests.Company.Role
{
    public class UpdateRoleRequest : BaseCompanyRequest
    {
        public string Name { get; set; }
        public List<int> Privileges { get; set; }
    }
}
