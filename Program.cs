using Microsoft.OpenApi.Models;
using PhraseGeneratorDomain.Domain;
using PhraseGeneratorDomain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços ao contêiner
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configuração detalhada do Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Demotivational Phrases API",
        Description = "API to generate/search random demotivational phrases",
        Contact = new OpenApiContact
        {
            Name = "Jhow",
            Email = "jhonatasrcorrea@gmail.com",
            Url = new Uri("https://github.com/CorreaJhow")
        }
    });
});

builder.Services.AddScoped<ISearchPhraseRandomDemotivational, SearchPhraseRandomDemotivational>();

var app = builder.Build();

app.UseRouting();
app.UseAuthorization();

// development middlewares 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.MapControllers();

try
{
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"Critical initialization failure: {ex}");
    throw;
}