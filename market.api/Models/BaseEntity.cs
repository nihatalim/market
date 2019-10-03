using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace market.api.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int ID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public BaseEntity()
        {
            this.DateCreated = DateTime.UtcNow;
            this.DateModified = DateTime.UtcNow;
        }
    }
}
