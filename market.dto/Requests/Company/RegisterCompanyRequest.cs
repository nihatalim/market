using market.dto.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Requests.Company
{
    public class RegisterCompanyRequest 
    {
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}
