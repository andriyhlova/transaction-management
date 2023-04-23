using TransactionManagement.DAL.Enums;

namespace TransactionManagement.BLL.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        public TransactionType Type { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}
