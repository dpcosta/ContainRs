using ContainRs.WebApp.Data;
using ContainRs.WebApp.Models;
using ContainRs.WebApp.Services;
using Microsoft.EntityFrameworkCore;
using Refit;


Email email = new Email("www.alura.com.br");
//DateTime data = new DateTime(2024, 16, 48);

return;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options
        .UseSqlServer(builder.Configuration.GetConnectionString("ContainRsDB"));
});

builder.Services
    .AddRefitClient<IViaCepService>()
    .ConfigureHttpClient(client =>
    {
        client.BaseAddress = new Uri("https://viacep.com.br");
        client.DefaultRequestHeaders.Add("Accept", "application/json");
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
