using TransactionManagement.BLL.Models;

namespace TransactionManagement.BLL.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<IList<TransactionModel>> GetAllAsync();

        Task<TransactionModel?> GetAsync(int id);

        Task CreateAsync(TransactionModel model);

        Task UpdateAsync(TransactionModel model);

        Task DeleteAsync(int id);
    }
}
