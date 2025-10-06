using System.Net.Http.Json;
using GrainBroker.Entities;
using GrainBroker.Entities.DTOs;

namespace GrainBroker.Frontend.Services
{
    public class SupplierHttpClient
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "api/Supplier";

        public SupplierHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Supplier>>(BaseUrl) ?? Enumerable.Empty<Supplier>();
        }

        public async Task<Supplier?> GetSupplierByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Supplier>($"{BaseUrl}/{id}");
        }

        public async Task<Supplier?> CreateSupplierAsync(CreateSupplierRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Supplier>();
        }

        public async Task<bool> UpdateSupplierAsync(Guid id, Supplier supplier)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", supplier);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteSupplierAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}