using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Requests.Company.Role
{
    public class DeleteRoleRequest : BaseCompanyRequest
    {
        public int RoleID { get; set; }
    }
}
