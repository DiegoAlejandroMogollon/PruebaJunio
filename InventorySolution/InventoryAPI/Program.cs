using InventoryAPI.Data;
using InventoryAPI.Interfaces;
using InventoryAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using InventoryAPI.Auth;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar DbContext con MySQL
builder.Services.AddDbContext<InventoryDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

// 2. Inyectar repositorios
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// 3. Agregar servicio para generar JWT
builder.Services.AddSingleton<JwtService>();

// 4. Configurar autenticación JWT
var jwtKey = builder.Configuration["Jwt:Key"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey!))
        };
    });

// 5. Agregar controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 6. Configurar el pipeline HTTP
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication(); // <-- Muy importante, va antes de Authorization
app.UseAuthorization();

app.MapControllers();
app.Run();
