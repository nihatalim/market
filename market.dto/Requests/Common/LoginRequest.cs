using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Requests.Common
{
    public class LoginRequest
    {
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}
