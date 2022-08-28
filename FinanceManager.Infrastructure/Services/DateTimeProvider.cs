using FinanceManager.Application.Common.Interfaces;

namespace FinanceManager.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }

}
