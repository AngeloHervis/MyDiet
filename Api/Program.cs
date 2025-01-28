using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

const string origemPermitida = "_origemPermitida";
builder.Services.AddCors(options =>
{
    options.AddPolicy(origemPermitida,
        corsPolicyBuilder =>
        {
            corsPolicyBuilder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


builder.Services.AddLogging(x => { x.AddConsole(); });

// Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MyDiet",
        Version = "v1"
    });

    c.ExampleFilters();

    c.CustomSchemaIds(x => x.FullName);

    const string xmlFile = "Api.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
});

// Swagger examples
builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());

// HttpClient
builder.Services.AddHttpClient();

// HttpContextAcessor
builder.Services.AddHttpContextAccessor();

// Add Services
Startup.ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

await Infra.Data.Startup.RunMigration(app);

if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Main")
{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyDiet API"); });    
}

app.UseHttpsRedirection();

app.UseCors(origemPermitida);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.RunAsync();