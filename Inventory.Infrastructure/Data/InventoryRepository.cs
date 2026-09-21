using Inventory.Application.AI;
using Inventory.Application.Data;
using Inventory.Domain.Product;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Inventory.Infrastructure.Data;
public class InventoryRepository : IInventoryRepository
{
    private readonly IApplicatonDbContext _applicatonDbContext;
    public InventoryRepository(IApplicatonDbContext applicatonDbContext)
    {
        _applicatonDbContext = applicatonDbContext;
    }

    public Task<string> GetProductInfoAsync(string productId, CancellationToken cancellationToken)
    {
        // Placeholder implementation. Replace with actual data retrieval logic.
        var product = _applicatonDbContext.Products.Where(x => string.Equals(x.Id, productId,StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        return Task.FromResult(JsonSerializer.Serialize(product));
    }

    public Task<string> GetProductAvailabilityAsync(string productId, CancellationToken cancellationToken)
    {
        // Placeholder implementation. Replace with actual data retrieval logic.
        return Task.FromResult($"Product availability for product ID {productId}.");
    }
    
}