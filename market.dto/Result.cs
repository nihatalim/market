using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto
{
    public class Result
    {
        public bool Status { get; set; }
        public string Message { get; set; }

        public Result()
        {
            this.Status = false;
        }
    }
}
