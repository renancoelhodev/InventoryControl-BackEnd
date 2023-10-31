namespace InventoryControl.Contracts.Products
{
    public record ProductRequest
    (
        int ProductId,
        string ProductName,
        int CategoryId
    );
}