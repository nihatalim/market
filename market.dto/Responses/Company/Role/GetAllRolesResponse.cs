using System;
using System.Collections.Generic;
using System.Text;

namespace market.dto.Responses.Company.Role
{
    public class GetAllRolesResponse : BaseResponse
    {
        public int Size { get; set; }
        public int Page { get; set; }
        public int SizeOfItems { get; set; }
        public int PageQuantity { get; set; }
        public ICollection<Models.Role> Roles { get; set; }
    }
}
