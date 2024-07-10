using WebAPI.Domain.Model;

namespace WebAPI.Infrastructure.Service
{
    public interface IImportDataService
    {
        public Task<BillingDTO> ImportFirstData();
        public Task<bool> ImportData();
    }
}