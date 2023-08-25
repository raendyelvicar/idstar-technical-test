using Dapper;
using TransactionsService.Data;
using TransactionsService.Entities;

namespace TransactionsService;
public class TransactionsRepository : ITransactionsRepository
{
    private readonly DapperContext _context;
    public TransactionsRepository(DapperContext context)
    {
        _context = context;
    }
    public async Task<bool> CreateTransactions(TransactionsHistory transactionsHistory)
    {
        var query = @"INSERT INTO TransactionsHistory(Id, UserId, TransactionsTypeId, Amount) 
                VALUES(@Id, @UserId, @TransactionsTypeId, @Amount)";
        using (var connection = _context.CreateConnection())
        {
            var transactions = await connection.ExecuteAsync(query, transactionsHistory);
            return transactions > 0;
        }
    }

    public Task<bool> DeleteTransactions(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TransactionsHistory>> GetAll()
    {
        var query = "SELECT * FROM TransactionsHistory";
        using (var connection = _context.CreateConnection())
        {
            var transactions = await connection.QueryAsync<TransactionsHistory>(query);
            return transactions.ToList();
        }
    }

    public async Task<IEnumerable<TransactionsHistory>> GetByTransactionsType(Guid id)
    {
        var query = "SELECT * FROM TransactionsHistory WHERE TransactionsTypeId = @id";
        using (var connection = _context.CreateConnection())
        {
            var transactions = await connection.QueryAsync<TransactionsHistory>(query, new {id});
            return transactions.ToList();
        }
    }

    public Task<bool> UpdateTransactions(TransactionsHistory transactionsHistory)
    {
        throw new NotImplementedException();
    }
}
