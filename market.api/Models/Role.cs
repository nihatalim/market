using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace market.api.Models
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<UserRole> Users { get; set; }
        public virtual ICollection<RolePrivilege> Privileges { get; set; }
    }
}
