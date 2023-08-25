namespace TransactionsService.Entities;
public class TransactionsHistory : BaseEntity
{ 
    public Guid Id { get; set;}
    public string UserId { get; set;}
    public Guid TransactionsTypeId { get; set;}
    public decimal Amount { get; set;}
}
