using Dating.Blazor.Components;
using Dating.Data.Crud;
using Dating.Data.Crud.Interface;
using Dating.Data.Models;
using Dating.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
//EntityFrameWork
builder.Services.AddDbContext<DatingContext>();
//Models    
builder.Services.AddScoped<ProfilDetail>();
builder.Services.AddScoped<AccountProfile>();
//Services
builder.Services.AddScoped<SimpleAuthService>();
//Crud
builder.Services.AddScoped<ICrud, EFCRUD>();
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
