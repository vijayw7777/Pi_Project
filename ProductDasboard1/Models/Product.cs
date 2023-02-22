using System;
using System.Collections.Generic;

namespace ProductDasboard1.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Image { get; set; }
        public string? Catagory { get; set; }
        public int? DescId { get; set; }
        public string? Colour { get; set; }
        public decimal? Price { get; set; }

        public virtual ProductDiscription? Desc { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
