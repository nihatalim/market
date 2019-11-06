using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace market.dto.Models
{
    public class UserRole : BaseDTO
    {
        public int UserID { get; set; }
        public User User { get; set; }
        public int RoleID { get; set;}
        public Role Role { get; set; }
        public int CompanyID { get; set; }
        public Company Company { get; set; }
    }
}
