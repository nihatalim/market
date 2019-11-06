using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace market.dto.Models
{
    public class RolePrivilege : BaseDTO
    {
        public int RoleID { get; set; }
        public Role Role { get; set; }
        public int PrivilegeID { get; set; }
        public Privilege Privilege { get; set; }
    }
}
