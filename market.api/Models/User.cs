using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace market.api.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public virtual ICollection<UserRole> Roles { get; set; }
    }
}
