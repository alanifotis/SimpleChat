// Package Dependencies
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


// Local Dependencies 
using SimpleChat.Components;
using SimpleChat.Hubs;
using SimpleChat.Data;
using SimpleChat.Controllers;

var builder = WebApplication.CreateBuilder(args);

// DBFile 
var connectionString = builder.Configuration.GetConnectionString("EmployeeDB");


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddServerSideBlazor();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();


builder.Services.AddDbContext<ChatMessagesDBContext>(options =>
        options.UseSqlite(connectionString), ServiceLifetime.Scoped);

builder.Services.AddSingleton<UserController>();


// Add SignalR Service
builder.Services.AddSignalR();

builder.Services.AddResponseCompression(opts =>
{
   opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
       ["application/octet-stream"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapControllerRoute("default", "{controller=Home}/api/users");

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.UseResponseCompression();
app.MapHub<ChatHub>("/chathub");

app.Run();
