using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TrueCode.Gateway.Api.Filters;
using TrueCode.Gateway.Configuration;
using TrueCode.Gateway.CurrencyClient;
using TrueCode.Gateway.UseCases;
using TrueCode.Gateway.UserClient;

var builder = WebApplication.CreateBuilder(args);

var appSettings = builder.GetAppSettings();
// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ExceptionFilterAttribute>();
});

builder.Services
    .AddCurrencyClient(appSettings)
    .AddUserClient(appSettings)
    .AddUseCases();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = appSettings.JwtSettings.Issuer,
            ValidateAudience = true,
            ValidAudience = appSettings.JwtSettings.Audience,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(appSettings.JwtSettings.Key))
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.IncludeXmlComments("TrueCode.Gateway.Api.xml", true);
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "¬ведите токен JWT",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
