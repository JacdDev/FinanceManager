using FinanceManager.UI.Models;

namespace FinanceManager.UI.Common.Interfaces
{
    public interface IResourcesService
    {
        public Task<HttpResponseMessage> Register(RegisterRequest request);
        public Task<HttpResponseMessage> Login(LoginRequest request);
    }
}
