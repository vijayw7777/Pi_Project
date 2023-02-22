using System;
using System.Collections.Generic;

namespace ProductDasboard1.Models
{
    public partial class Customer
    {
        public Customer()
        {
            OrderTbls = new HashSet<OrderTbl>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? City { get; set; }
        public string? State { get; set; }

        public virtual ICollection<OrderTbl> OrderTbls { get; set; }
    }
}
