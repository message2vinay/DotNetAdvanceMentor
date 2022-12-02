using ShoppingCart.API.Data;
using Microsoft.Extensions.Configuration;
using Catalog.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<LiteDbOptions>(
    builder.Configuration.GetSection(LiteDbOptions.DbOptions));
builder.Services.AddSingleton<ICartDbContext, CartDbContext>();
builder.Services.AddTransient<ICartRepository, CartRepository>();
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
