using market.dto.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto
{
    public class BaseResponse 
    {
        public Result Result { get; set; }

        public BaseResponse()
        {
            this.Result = new Result();
        }
    }
}
