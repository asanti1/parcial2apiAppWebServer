using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using segParAgustinSantinaqueApi.Dal;
using segParAgustinSantinaqueApi.Dal.Data;
using segParAgustinSantinaqueApi.Dal.Repository;
using segParAgustinSantinaqueApi.Dal.Repository.Interface;
using segParAgustinSantinaqueApi.Service;
using segParAgustinSantinaqueApi.Service.Interface;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "JWT", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Ingrese Token",
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference
                { Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}

        }
    });
});
builder.Services.AddDbContext<DataContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStringEF")));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<ICancionService, CancionService>();
builder.Services.AddScoped<IDiscoService, DiscoService>();
builder.Services.AddScoped<ILoginService, LoginService>();


builder.Services.AddScoped<ICancionRepository, CancionRepository>();
builder.Services.AddScoped<IDiscoRepository, DiscoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(x =>
    new UnitOfWork(x.GetRequiredService<DataContext>(),
        x.GetRequiredService<ICancionRepository>(),
        x.GetRequiredService<IDiscoRepository>(),
    x.GetRequiredService<IUsuarioRepository>()));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

var configuration = new
    ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
Log.Logger = new
    LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
