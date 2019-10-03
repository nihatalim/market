using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace market.api.Models
{
    public class Admin : BaseEntity
    {
        public string Name { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
