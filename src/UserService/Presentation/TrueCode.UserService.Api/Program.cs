using Microsoft.AspNetCore.Identity;
using TrueCode.UserService.Api;
using TrueCode.UserService.Api.Services;
using TrueCode.UserService.Configuration;
using TrueCode.UserService.Data;

var builder = WebApplication.CreateBuilder(args);
var appSettings = builder.GetAppSettings();

// Add services to the container.
builder.Services.AddGrpc();

builder.Services
    .AddDataServices(appSettings)
    .AddSingleton<TokenService>();

builder.Services
    .AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<UserDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<AuthService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
