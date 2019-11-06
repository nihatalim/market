using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Requests.Company.Role
{
    public class DeleteUserFromRoleRequest : BaseCompanyRequest
    {
        public int RoleID { get; set; }
        public int UserID { get; set; }
    }
}
