using System;
using Microsoft.EntityFrameworkCore;
using MvcSmartStore.Data;

var builder = WebApplication.CreateBuilder(args);

// dodane
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSession();//session for login

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();//session

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Smartphone}/{action=All}");

app.Run();
