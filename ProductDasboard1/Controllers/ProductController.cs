using Microsoft.AspNetCore.Mvc;
using ProductDasboard1.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductDasboard1.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDbContext context;

        public ProductController(ProductDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {


            return View();
        }
        public JsonResult ProductinfoList()
        {

            List<IndexViewModel> data = context.IndexViewModels.FromSqlInterpolated($"EXEC AllProductInfo").ToList();
            
            // var data = context.IndexViewModels.FromSqlRaw($"EXEC ProductCountDetails")
            //.ToList();
           

            List<string> products = new List<string>() { "1", "2", "3", "4", "5", };
              //var data= ActionResult(list);
            return new JsonResult(data);
        }
        public JsonResult OrderList(int id)
        {

            var order = context.OrderProducts.Where(a => a.ProductId == id).Select(a => a.OrderId).ToList();
            List<OrderTbl> orders = new List<OrderTbl>();
            foreach (var oId in order)
            {
                var ord = context.OrderTbls.Where(a => a.OrderId == oId).SingleOrDefault();
                orders.Add(ord);
            }
            //var res = JsonConvert.SerializeObject(list);
            return new JsonResult(orders);
        }

        public JsonResult CustomerList(int id)
        {
            var result = from op in context.OrderProducts
                         join o in context.OrderTbls on op.OrderId equals o.OrderId
                         join p in context.Products on op.ProductId equals p.ProductId
                         where op.ProductId == id
                         group new { op, o } by new { o.CustomerId, op.ProductId } into g
                         select new
                         {
                             ProductId = g.Key.ProductId,
                             CustomerId = g.Key.CustomerId
                         };

            List<Customer> Customer = new List<Customer>();
            foreach (var o in result)
            {
                var ct = context.Customers.Where(a => a.CustomerId == o.CustomerId).SingleOrDefault();
                Customer.Add(ct);
            }


            return new JsonResult(Customer);
        }

        public JsonResult SearchByProductName(string name)
        {

            List<IndexViewModel> data = context.IndexViewModels.FromSqlInterpolated($"EXEC SearchByProductName {name}").ToList();

            // var data = context.IndexViewModels.FromSqlRaw($"EXEC ProductCountDetails")
            //.ToList();
            return new JsonResult(data);
        }








    }
}
