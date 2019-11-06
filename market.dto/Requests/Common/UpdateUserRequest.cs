using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Requests.Common
{
    public class UpdateUserRequest
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
