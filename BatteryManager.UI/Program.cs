using Microsoft.FluentUI.AspNetCore.Components;
using BatteryManager.UI.Components;
using BatteryManager.UI.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BatteryManager.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddFluentUIComponents();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IPlantService, PlantService>();
builder.Services.AddScoped<IBatteryService, BatteryService>();
builder.Services.AddScoped<IImportService, ImportService>();

builder.Services.AddDbContextFactory<BatteryManagerContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("BatteryManager")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
