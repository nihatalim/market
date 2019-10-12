using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Models
{
    public class Admin : BaseDTO
    {
        public string Name { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
