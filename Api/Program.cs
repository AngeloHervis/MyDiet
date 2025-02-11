using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using Domain.Autentication;
using Infra.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Startup = Infra.IoC.Startup;

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

builder.Services.AddIdentity<User, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<MyDietContext>()
    .AddDefaultTokenProviders();


var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var key = Encoding.UTF8.GetBytes(jwtSettings["Secret"]!);

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidateAudience = true,
            ValidAudience = jwtSettings["Audience"],
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization();

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