using System;
using System.Collections.Generic;

namespace ProductDasboard1.Models
{
    public partial class OrderTbl
    {
        public OrderTbl()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
