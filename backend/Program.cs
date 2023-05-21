using backend.Entity;
using backend.Repository;
using backend.Services;
using backend.Services.Impl;
using backend.Utils;
using backend.Utils.Impl;
using DeepL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddScoped<ITranslator>(ServiceProvider =>
{
    var authKey = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("DeepL")["AuthenticationKey"];
    if (String.IsNullOrEmpty(authKey))
    {
        throw new Exception("Authentication Key is required");
    }
    return new Translator(authKey);
});
builder.Services.AddScoped<ILanguageMapper, LanguageMapper>();
builder.Services.AddScoped<WordRepository>();
builder.Services.AddScoped<ITranslateService, TranslateService>();
builder.Services.AddScoped<IWordService, WordService>();
builder.Services.AddDbContext<WordDbContext>(
            dbContextOptions =>
            {
                var connStr = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];
                var serverVersion = new MySqlServerVersion(new Version(8, 0));
                dbContextOptions
               .UseMySql(connStr, serverVersion)
               // The following three options help with debugging, but should
               // be changed or removed for production.
               .LogTo(Console.WriteLine, LogLevel.Information)
               .EnableSensitiveDataLogging()
               .EnableDetailedErrors();
            }
        );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
