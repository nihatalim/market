using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Models
{
    public class User : BaseDTO
    {
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Role Role { get; set; }
    }

    public enum Role
    {
        ADMIN = 0,
        COMPANY = 1
    }
}
