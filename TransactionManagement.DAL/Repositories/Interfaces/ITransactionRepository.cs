using TransactionManagement.DAL.Entities;

namespace TransactionManagement.DAL.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task<IList<TransactionEntity>> GetAllAsync();

        Task<TransactionEntity?> GetAsync(int id);

        Task CreateAsync(TransactionEntity entity);

        Task UpdateAsync(TransactionEntity entity);

        Task DeleteAsync(int id);
    }
}
