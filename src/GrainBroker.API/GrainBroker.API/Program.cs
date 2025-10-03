using Microsoft.EntityFrameworkCore;
using GrainBroker.API.Data;
using GrainBroker.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<GrainBrokerContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=grainbroker.db"));

builder.Services.AddScoped<CsvImportService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Initialize database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<GrainBrokerContext>();
        context.Database.EnsureCreated();
        
        // Import sample data if database is empty
        if (!context.Suppliers.Any())
        {
            var csvService = services.GetRequiredService<CsvImportService>();
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "SampleData");
            await csvService.ImportSuppliersFromCsvAsync(Path.Combine(basePath, "suppliers.csv"));
            await csvService.ImportCustomersFromCsvAsync(Path.Combine(basePath, "customers.csv"));
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while initializing the database.");
    }
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
