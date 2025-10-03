using System.Globalization;
using GrainBroker.API.Data;
using GrainBroker.API.Models;

namespace GrainBroker.API.Services
{
    public class CsvImportService
    {
        private readonly GrainBrokerContext _context;
        private readonly ILogger<CsvImportService> _logger;

        public CsvImportService(GrainBrokerContext context, ILogger<CsvImportService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> ImportSuppliersFromCsvAsync(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    _logger.LogError("CSV file not found: {FilePath}", filePath);
                    return false;
                }

                var lines = await File.ReadAllLinesAsync(filePath);
                if (lines.Length < 2)
                {
                    _logger.LogWarning("CSV file is empty or has no data rows");
                    return false;
                }

                for (int i = 1; i < lines.Length; i++)
                {
                    var line = lines[i];
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var values = line.Split(',');
                    if (values.Length < 5) continue;

                    var supplier = new Supplier
                    {
                        Name = values[0].Trim(),
                        Location = values[1].Trim(),
                        Capacity = int.TryParse(values[2].Trim(), out var capacity) ? capacity : 0,
                        PricePerUnit = decimal.TryParse(values[3].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out var price) ? price : 0,
                        GrainType = values[4].Trim()
                    };

                    _context.Suppliers.Add(supplier);
                }

                await _context.SaveChangesAsync();
                _logger.LogInformation("Successfully imported suppliers from CSV");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error importing suppliers from CSV");
                return false;
            }
        }

        public async Task<bool> ImportCustomersFromCsvAsync(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    _logger.LogError("CSV file not found: {FilePath}", filePath);
                    return false;
                }

                var lines = await File.ReadAllLinesAsync(filePath);
                if (lines.Length < 2)
                {
                    _logger.LogWarning("CSV file is empty or has no data rows");
                    return false;
                }

                for (int i = 1; i < lines.Length; i++)
                {
                    var line = lines[i];
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var values = line.Split(',');
                    if (values.Length < 4) continue;

                    var customer = new Customer
                    {
                        Name = values[0].Trim(),
                        Location = values[1].Trim(),
                        ContactEmail = values[2].Trim(),
                        ContactPhone = values.Length > 3 ? values[3].Trim() : null
                    };

                    _context.Customers.Add(customer);
                }

                await _context.SaveChangesAsync();
                _logger.LogInformation("Successfully imported customers from CSV");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error importing customers from CSV");
                return false;
            }
        }
    }
}
