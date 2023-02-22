using System;
using System.Collections.Generic;

namespace ProductDasboard1.Models
{
    public partial class ProductDiscription
    {
        public ProductDiscription()
        {
            Products = new HashSet<Product>();
        }

        public int DescId { get; set; }
        public string Discription { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
