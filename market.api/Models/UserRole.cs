using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace market.api.Models
{
    public class UserRole : BaseEntity
    {
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public int RoleID { get; set;}
        public virtual Role Role { get; set; }
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }
    }
}
