using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace market.dto.Models
{
    public class Role : BaseDTO
    {
        public string Name { get; set; }
        public int CompanyID { get; set; }
        public Company Company { get; set; }
        public ICollection<UserRole> Users { get; set; }
        public ICollection<RolePrivilege> Privileges { get; set; }
    }
}
