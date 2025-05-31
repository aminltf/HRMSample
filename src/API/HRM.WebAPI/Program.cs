using HRM.WebFramework.Extensions.DependencyInjection;
using HRM.Infrastructure.Identity.Extensions;
using HRM.WebFramework.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register Services Collection
builder.Services.AddServices(builder.Host, builder.Configuration);

var app = builder.Build();

// Run Seeder (with Extension Method)
await app.UseIdentitySeederAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<RequestTimingMiddleware>();
app.UseMiddleware<ValidationExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
