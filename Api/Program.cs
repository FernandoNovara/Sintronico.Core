using Application.Services;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Logging;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

LoggerConfig.ConfigureLogging();
builder.Host.UseSerilog();

builder.Services.AddScoped<ILogService<LogService>,LogService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sintronico.Core.Api", Version = "1.0.0.0" });
    c.CustomSchemaIds(type => type.FullName); //-> Permite obtener el operation id desde el atributo name de annotation 
    //c.CustomOperationIds(api => api.TryGetMethodInfo(out var mi) ? mi.Name : null); //-> Permite agregar el operacion id obteniendolo desde el name del metodo
});

builder.Services.AddDbContext<SintronicoDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBikeRepository, BikeRepository>();
builder.Services.AddScoped<BikeServices>();
//builder.Services.AddScoped<ILogService, LogService>();

builder.Services.AddCors(
    options =>
    {
        options.AddDefaultPolicy(
            policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            }
            );
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.yaml", "Sintronico.Core.Api");
        c.RoutePrefix = string.Empty;
    });
}

app.UseCors();

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
