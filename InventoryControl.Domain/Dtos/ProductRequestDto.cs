namespace InventoryControl.Application.Dtos
{
    public record ProductRequestDto
    (
        int ProductId,
        string ProductName,
        int CategoryId
    );
    

}