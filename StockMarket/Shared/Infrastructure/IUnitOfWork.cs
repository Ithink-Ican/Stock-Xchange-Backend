namespace StockMarket.Common.Infrastructure
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default
            );
    }
}