namespace InventoryControl.Contracts.Products
{
    public record ProductResponse
    (
        int ProductId,
        string ProductName,
        string CategoryName
    );
}