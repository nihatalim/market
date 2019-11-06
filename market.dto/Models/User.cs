using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Models
{
    public class User : BaseDTO
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public ICollection<UserRole> Roles { get; set; }
    }
}
