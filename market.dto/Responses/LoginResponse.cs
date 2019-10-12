using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Responses
{
    public class LoginResponse : BaseResponse
    {
        public string Token { get; set; }
    }
}
