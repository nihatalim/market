using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace market.api.Models
{
    public class User : BaseEntity
    {
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public Role Role { get; set; }
    }

    public enum Role
    {
        ADMIN = 0,
        COMPANY = 1
    }
}
