using Microsoft.EntityFrameworkCore;
using WebApplication8.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<WebapidbContext>(item => item.UseSqlServer(config.GetConnectionString("dbcs")));


var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/Swagger/v1/swagger.json", "Dispatch API v1");
        c.RoutePrefix = string.Empty;
    });
}

// Other middleware...

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

app.Run();
