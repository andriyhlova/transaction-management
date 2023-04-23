using TransactionManagement.BLL.Models;
using TransactionManagement.BLL.Services.Interfaces;
using TransactionManagement.DAL.Entities;
using TransactionManagement.DAL.Repositories.Interfaces;

namespace TransactionManagement.BLL.Services.Implementations
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<IList<TransactionModel>> GetAllAsync()
        {
            var allTransactions = await _transactionRepository.GetAllAsync();
            return allTransactions.Select(x => new TransactionModel
            {
                Id = x.Id,
                Amount = x.Amount,
                Type = x.Type,
                Date = x.Date,
                Description = x.Description
            }).ToList();
        }

        public async Task<TransactionModel?> GetAsync(int id)
        {
            var transaction = await _transactionRepository.GetAsync(id);
            if (transaction is null)
            {
                return null;
            }

            return new TransactionModel
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                Date = transaction.Date,
                Type = transaction.Type,
                Description = transaction.Description
            };
        }

        public async Task CreateAsync(TransactionModel model)
        {
            var transaction = new TransactionEntity
            {
                Id = model.Id,
                Amount = model.Amount,
                Date = model.Date.ToUniversalTime(),
                Type = model.Type,
                Description = model.Description
            };

            await _transactionRepository.CreateAsync(transaction);
        }

        public async Task UpdateAsync(TransactionModel model)
        {
            var transaction = new TransactionEntity
            {
                Id = model.Id,
                Amount = model.Amount,
                Date = model.Date.ToUniversalTime(),
                Type = model.Type,
                Description = model.Description
            };

            await _transactionRepository.UpdateAsync(transaction);
        }

        public async Task DeleteAsync(int id)
        {
            await _transactionRepository.DeleteAsync(id);
        }

        public async Task<decimal> GetTotalForDateAsync(DateTime date)
        {
            var transactions = await _transactionRepository.GetAllAsync();
            var sum = 0m;
            for (var i = 0; i < transactions.Count; i++)
            {
                if (transactions[i].Date == date)
                {
                    sum += transactions[i].Amount;
                }
            }

            return sum;
        }
    }
}
