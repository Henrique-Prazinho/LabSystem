using Microsoft.EntityFrameworkCore;
using SistemaLab.Data;


var builder = WebApplication.CreateBuilder(args);

//Configura��o middleware de sess�o
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
                           {
                               options.IdleTimeout = TimeSpan.FromMinutes(60); //Tempo de sess�o
                               options.Cookie.HttpOnly = true; //Garante que s� ser� acess�vel ao servidor
                               options.Cookie.IsEssential = true;
                           });

builder.Services.AddDbContext<SistemaLabContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("SistemaLabContext"),
    new MySqlServerVersion(new Version(8, 0, 42)), //Informa vers�o do MySql
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

app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
