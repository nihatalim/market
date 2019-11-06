using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace market.api.Models
{
    public class RolePrivilege : BaseEntity
    {
        public int RoleID { get; set; }
        public virtual Role Role { get; set; }
        public int PrivilegeID { get; set; }
        public virtual Privilege Privilege { get; set; }
    }
}
