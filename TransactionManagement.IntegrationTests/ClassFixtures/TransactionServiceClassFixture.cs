using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using TransactionManagement.DAL.DataAccess;
using TransactionManagement.DAL.Entities;
using TransactionManagement.DAL.Repositories.Implementations;
using TransactionManagement.DAL.Repositories.Interfaces;

namespace TransactionManagement.IntegrationTests.ClassFixtures
{
    public class TransactionServiceClassFixture
    {
        public ITransactionRepository TransactionRepository { get; }

        private readonly AppDbContext _context;

        public TransactionServiceClassFixture()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();

            var contextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(connection)
                .Options;

            _context = new AppDbContext(contextOptions);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _context.AddRange(new List<TransactionEntity>
                {
                    new TransactionEntity{ Id = 1, Date= new DateTime(2023, 04, 11), Amount = 2 },
                    new TransactionEntity{ Id = 2, Date= new DateTime(2023, 04, 11), Amount = 8 },
                    new TransactionEntity{ Id = 3, Date= new DateTime(2023, 04, 10), Amount = 2 }
                });

            _context.SaveChanges();

            TransactionRepository = new TransactionRepository(_context);
        }

        public void Dispose() => _context.Dispose();
    }
}
