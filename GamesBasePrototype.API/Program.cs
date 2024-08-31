using GamesBasePrototype.API.Mappers;
using GamesBasePrototype.API.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Obtém a string de conexão do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("GamesBaseCs");

// Configura o DbContext para usar o SQL Server com a string de conexão correta
builder.Services.AddDbContext<GamesBaseDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(GamesBaseProfile));

// Configuração do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
// Configuração do Swagger para documentação da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "GamesBasePrototype.API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "João Ricardo",
            Email = "joaoricardo.ifc@gmail.com",
            Url = new Uri("https://joaodev.com.br")
        }
    });

    var xmlFile = "GamesBasePrototype.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configuração do pipeline de requisições
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Adiciona o middleware de CORS
app.UseCors("AllowAll");

app.UseAuthorization();
app.MapControllers();
app.Run();