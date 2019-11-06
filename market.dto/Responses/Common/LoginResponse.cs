using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Responses.Common
{
    public class LoginResponse : BaseResponse
    {
        public string Token { get; set; }
    }
}
