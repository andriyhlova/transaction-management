using Microsoft.EntityFrameworkCore;
using TransactionManagement.DAL.DataAccess;
using TransactionManagement.DAL.Entities;
using TransactionManagement.DAL.Repositories.Interfaces;

namespace TransactionManagement.DAL.Repositories.Implementations
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;

        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IList<TransactionEntity>> GetAllAsync()
        {
            return await _context.Transactions.AsNoTracking().ToListAsync();
        }

        public async Task<TransactionEntity?> GetAsync(int id)
        {
            return await _context.Transactions.FindAsync(id);
        }

        public async Task CreateAsync(TransactionEntity entity)
        {
            _context.Transactions.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TransactionEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existingEntity = await GetAsync(id);
            _context.Entry(existingEntity!).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
