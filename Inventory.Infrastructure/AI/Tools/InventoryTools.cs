using System.ComponentModel;
using Inventory.Domain.Product;

namespace Inventory.Infrastructure.AI.Tools;

public sealed class InventoryTools
{
    private readonly IInventoryRepository _inventoryRepository;
    public InventoryTools(IInventoryRepository inventoryRepository)
    {
        this._inventoryRepository = inventoryRepository;
    }

    [Description("Gets the current product details.")]
    public async Task<string> GetProductInfoAsync(
        [Description("The product id.")] string productId,
        CancellationToken cancellationToken)
    {
        return await _inventoryRepository.GetProductInfoAsync(
            productId,
            cancellationToken);
    }

    [Description("Gets the product availability status of inventory lists.")]
    public async Task<string> GetProductAvailabilityAsync(
        [Description("The product id.")] string productId,
        CancellationToken cancellationToken)
    {
        return await _inventoryRepository.GetProductAvailabilityAsync(
            productId,
            cancellationToken);
    }

}