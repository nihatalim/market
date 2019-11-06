using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Requests.Company.Role
{
    public class AddUserToRoleRequest : BaseCompanyRequest
    {
        public int RoleID { get; set; }
        public string Mail { get; set; }
    }
}
