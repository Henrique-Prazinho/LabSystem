using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SistemaLab.Data;
using Pomelo.EntityFrameworkCore.MySql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SistemaLabContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("SistemaLabContext"),
    new MySqlServerVersion(new Version(8, 0, 42)), //Informa versão do MySql
    builder => builder.MigrationsAssembly("SistemaLab"))); //Informa onde procurar as Migrations do DB



builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
