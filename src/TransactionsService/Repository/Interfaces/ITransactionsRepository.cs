using TransactionsService.Entities;

namespace TransactionsService;
public interface ITransactionsRepository
{
    Task<IEnumerable<TransactionsHistory>> GetAll();
    Task<IEnumerable<TransactionsHistory>> GetByTransactionsType(Guid id);
    Task<bool> CreateTransactions(TransactionsHistory transactionsHistory);
    Task<bool> UpdateTransactions(TransactionsHistory transactionsHistory);
    Task<bool> DeleteTransactions(Guid id);
}
