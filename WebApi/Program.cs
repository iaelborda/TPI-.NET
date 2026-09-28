using Application.Services;
using Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApi;
using WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "Ingrese el token JWT.",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });
});

// Add Entity Framework Context
builder.Services.AddDbContext<TPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Dependency Injection
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.AddScoped<IBicicletaRepository, BicicletaRepository>();
builder.Services.AddScoped<IBicicletaService, BicicletaService>();

builder.Services.AddScoped<ISucursalRepository, SucursalRepository>();
builder.Services.AddScoped<ISucursalService, SucursalService>();

builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();

// Add JWT Authentication
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"];
var issuer = jwtSettings["Issuer"];
var audience = jwtSettings["Audience"];

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = issuer,
            ValidateAudience = true,
            ValidAudience = audience,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(secretKey!)),
            ClockSkew = TimeSpan.Zero
        };
    });

// Add Authorization Policies
builder.Services.AddAuthorization(options =>
{
    // Políticas para Clientes
    options.AddPolicy("ClientesLeer", policy => policy.RequireClaim("permission", "clientes.leer"));
    options.AddPolicy("ClientesAgregar", policy => policy.RequireClaim("permission", "clientes.agregar"));
    options.AddPolicy("ClientesActualizar", policy => policy.RequireClaim("permission", "clientes.actualizar"));
    options.AddPolicy("ClientesEliminar", policy => policy.RequireClaim("permission", "clientes.eliminar"));

    // Políticas para Bicicletas
    options.AddPolicy("BicicletasLeer", policy => policy.RequireClaim("permission", "bicicletas.leer"));
    options.AddPolicy("BicicletasAgregar", policy => policy.RequireClaim("permission", "bicicletas.agregar"));
    options.AddPolicy("BicicletasActualizar", policy => policy.RequireClaim("permission", "bicicletas.actualizar"));
    options.AddPolicy("BicicletasEliminar", policy => policy.RequireClaim("permission", "bicicletas.eliminar"));

    // Políticas para Sucursales
    options.AddPolicy("SucursalesLeer", policy => policy.RequireClaim("permission", "sucursales.leer"));
    options.AddPolicy("SucursalesAgregar", policy => policy.RequireClaim("permission", "sucursales.agregar"));
    options.AddPolicy("SucursalesActualizar", policy => policy.RequireClaim("permission", "sucursales.actualizar"));
    options.AddPolicy("SucursalesEliminar", policy => policy.RequireClaim("permission", "sucursales.eliminar"));

    // Políticas para Categorías
    options.AddPolicy("CategoriasLeer", policy => policy.RequireClaim("permission", "categorias.leer"));
    options.AddPolicy("CategoriasAgregar", policy => policy.RequireClaim("permission", "categorias.agregar"));
    options.AddPolicy("CategoriasActualizar", policy => policy.RequireClaim("permission", "categorias.actualizar"));
    options.AddPolicy("CategoriasEliminar", policy => policy.RequireClaim("permission", "categorias.eliminar"));

    // Políticas para Empleados
    options.AddPolicy("EmpleadosLeer", policy => policy.RequireClaim("permission", "empleados.leer"));
    options.AddPolicy("EmpleadosAgregar", policy => policy.RequireClaim("permission", "empleados.agregar"));
    options.AddPolicy("EmpleadosActualizar", policy => policy.RequireClaim("permission", "empleados.actualizar"));
    options.AddPolicy("EmpleadosEliminar", policy => policy.RequireClaim("permission", "empleados.eliminar"));

    // Políticas para Alquileres
    options.AddPolicy("AlquileresLeer", policy => policy.RequireClaim("permission", "alquileres.leer"));
    options.AddPolicy("AlquileresAgregar", policy => policy.RequireClaim("permission", "alquileres.agregar"));
    options.AddPolicy("AlquileresActualizar", policy => policy.RequireClaim("permission", "alquileres.actualizar"));
    options.AddPolicy("AlquileresEliminar", policy => policy.RequireClaim("permission", "alquileres.eliminar"));
});

// Configure the HTTP request pipeline.
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseAuthentication();
app.UseAuthorization();

// Map endpoints
app.MapAuthEndpoints();

app.MapClienteEndpoints();
app.MapBicicletaEndpoints();
app.MapSucursalEndpoints();
app.MapCategoriaEndpoints();
app.MapEmpleadoEndpoints();
app.MapAlquilerEndpoints();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TPIContext>();
    db.Database.Migrate();
}

app.Run();
