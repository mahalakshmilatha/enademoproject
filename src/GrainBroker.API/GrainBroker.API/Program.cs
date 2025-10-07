using GrainBroker.Entities;
using GrainBroker.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<GrainBrokerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IFulfillmentService, FulfillmentService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorApp",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS before routing
app.UseCors("AllowBlazorApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
