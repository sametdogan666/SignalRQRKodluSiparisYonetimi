namespace SignalR.Dto.BasketDto;

public class ResultBasketWithProductDto
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
    public decimal TotalPrice { get; set; }
    public string? ProductName{ get; set; }
    public int MenuTableId { get; set; }

}