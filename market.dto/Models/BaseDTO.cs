using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Models
{
    public class BaseDTO
    {
        public int ID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public BaseDTO()
        {
            this.DateCreated = DateTime.UtcNow;
            this.DateModified = DateTime.UtcNow;
        }
    }
}
