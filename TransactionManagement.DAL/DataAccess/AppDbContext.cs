using Microsoft.EntityFrameworkCore;
using TransactionManagement.DAL.Entities;

namespace TransactionManagement.DAL.DataAccess
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<TransactionEntity> Transactions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
