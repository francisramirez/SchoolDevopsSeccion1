using Microsoft.EntityFrameworkCore;
using School.Data.Context;
using School.Data.Interfaces;
using School.Data.Repositories.Mocks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<BoletosContext>(options => options.UseInMemoryDatabase("BoletoBus"));

builder.Services.AddScoped<IAsientoRepository, MockAsientoRepository>();


builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
