using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RecipeFinder.Data;

var builder = WebApplication.CreateBuilder(args);

// 注册 MVC
builder.Services.AddControllersWithViews();

// 注册 SQLite 数据库
builder.Services.AddDbContext<RecipeDbContext>(options =>
    options.UseSqlite("Data Source=recipes.db"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
    app.UseExceptionHandler("/Home/Error");

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
