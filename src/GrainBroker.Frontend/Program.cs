using GrainBroker.Frontend;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Load configuration
builder.Services.AddScoped(sp => {
    var client = new HttpClient { 
        BaseAddress = new Uri(builder.Configuration["ApiSettings:BaseUrl"] ?? "https://localhost:7087/")
    };
    return client;
});

// Register HTTP client services
builder.Services.AddScoped<CustomerHttpClient>();
builder.Services.AddScoped<OrderHttpClient>();
builder.Services.AddScoped<SupplierHttpClient>();
builder.Services.AddScoped<FulfillmentHttpClient>();

await builder.Build().RunAsync();
