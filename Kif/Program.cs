using Kif;
using Kif.Data;
using Kif.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

var builder = WebApplication.CreateBuilder(args);
var tax = Environment.GetEnvironmentVariable("TAX_RATE") ?? builder.Configuration["TAX_RATE"];
if (!decimal.TryParse(tax, out decimal taxRate))
{
    throw new InvalidOperationException("خطا: مقدار TAX_RATE یک عدد معتبر نیست!");
}
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.Configure<TaxSettings>(builder.Configuration.GetSection("TAX"));
builder.Services.AddScoped<WalletService>();
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("DB"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
