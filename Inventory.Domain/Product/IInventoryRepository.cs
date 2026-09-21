namespace Inventory.Domain.Product
{
    public interface IInventoryRepository
    {
        Task<string> GetProductInfoAsync(string productId, CancellationToken cancellationToken);
        Task<string> GetProductAvailabilityAsync(string productId, CancellationToken cancellationToken);
    }
}
