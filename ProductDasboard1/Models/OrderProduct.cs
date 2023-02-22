using System;
using System.Collections.Generic;

namespace ProductDasboard1.Models
{
    public partial class OrderProduct
    {
        public int OrderProductId { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? LineTotal { get; set; }

        public virtual OrderTbl? Order { get; set; }
        public virtual Product? Product { get; set; }
    }
}
