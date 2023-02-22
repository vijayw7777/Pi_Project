using Microsoft.EntityFrameworkCore;
using ProductDasboard1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProductDbContext>(options => options.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ProductDb;Trusted_Connection=True;MultipleActiveResultSets=true;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=product}/{action=Index}/{id?}");

app.Run();
