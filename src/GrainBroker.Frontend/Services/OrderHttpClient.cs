using System.Net.Http.Json;
using GrainBroker.Entities;
using GrainBroker.Entities.DTOs;

namespace GrainBroker.Frontend.Services
{
    public class OrderHttpClient
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "api/Order";

        public OrderHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Order>>(BaseUrl) ?? Enumerable.Empty<Order>();
        }

        public async Task<Order?> GetOrderByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Order>($"{BaseUrl}/{id}");
        }

        public async Task<Order?> CreateOrderAsync(CreateOrderRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Order>();
        }

        public async Task<bool> UpdateOrderAsync(Guid id, Order order)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", order);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteOrderAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}