using FinanceManager.UI.Common.Interfaces;
using FinanceManager.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.UI.Common.Services
{
    public class ApiService : IResourcesService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> Register(RegisterRequest request)
        {
            return await _httpClient.PostAsJsonAsync<RegisterRequest>("api/authentication/register", request);
        }
    }
}
