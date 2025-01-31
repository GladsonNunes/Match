using Match.Api.Infra.DependencyInejectionExtensions;
using Match.Domain.Core;
using Match.Domain.Developer;
using Match.Domain.Project;
using Match.Infrastructure;
using Match.Infrastructure.Core;
using Match.Infrastructure.Developer;
using Match.Infrastructure.Project;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("ORACLE"),
        b=>b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
});


builder.Services.AddScoped(typeof(IRepCore<>), typeof(RepCore<>));
builder.Services.AddScoped(typeof(IServCore<>), typeof(ServCore<>));

builder.Services.AddScoped<IRepDeveloper, RepDeveloper>();
builder.Services.AddScoped<IRepProject, RepProject>();

builder.Services.AddApplicationServices();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

var app = builder.Build();

// Executar as migrations automaticamente
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
}

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
