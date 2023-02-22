namespace ProductDasboard1.Models
{
  
    public class IndexViewModel
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Image { get; set; }
        public string? Discription { get; set; }
        public decimal Price { get; set; }
        public int CountOfCustomerPerProduct { get; set; }
        public int CountOfOrderPerProduct { get; set; }
        public int TotaleQuantityPerProduct { get; set; }
        public decimal TotalRevenuePerProduct { get; set; }
    }
}
