using Microsoft.EntityFrameworkCore;
using MTS.Persistence.Context;
using MTS.Application.Interfaces;
using MTS.Persistence.Repositories;
using Microsoft.OpenApi.Models;
using AutoMapper;
using System.Reflection;
using MTS.Application.Services;
using MTS.Application.Services.Advisors;
using MTS.Application.Services.Students;
using MTS.Application.Mappings;
using MTS.Application.Interfaces.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuration
var configuration = builder.Configuration;

// 2. DbContext Registration (Scoped olarak daha uygun)
builder.Services.AddDbContext<MtsDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("MtsDbContext")),
    ServiceLifetime.Scoped);

// 3. Repository Registration (Generic repository eklenmemiş)
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IAdvisorRepository, AdvisorRepository>();
builder.Services.AddScoped<IThesisRepository, ThesisRepository>();

// 4. Service Registration
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IAdvisorService, AdvisorService>();
builder.Services.AddScoped<IThesisService, ThesisService>();
builder.Services.AddHttpClient();


// 5. AutoMapper (Daha spesifik assembly belirtmek daha iyi)
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(AutoMapperProfile)));

// 6. Controllers
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// 7. Swagger/OpenAPI (Daha detaylı bilgi eklenebilir)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MTS API",
        Version = "v1",
        Description = "Tez Yönetim Sistemi API",
        Contact = new OpenApiContact { Name = "IT Departmanı", Email = "it@firma.com" }
    });

    // XML comments eklenebilir
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Middleware Pipeline
app.UseStaticFiles();
app.UseDefaultFiles(new DefaultFilesOptions
{
    RequestPath = "",
    DefaultFileNames = new List<string> { "Mts/index.html" }
});
app.UseRouting();
app.UseCors("AllowAll"); 
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


// Swagger ile API dökümantasyonu
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MTS API v1");
        c.RoutePrefix = "api-docs"; // Özel bir route
    });
}

// 9. Exception Handling (Geliştirme için)
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


app.Run();
