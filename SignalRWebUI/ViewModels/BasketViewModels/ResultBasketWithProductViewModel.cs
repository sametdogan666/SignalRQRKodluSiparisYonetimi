namespace SignalRWebUI.ViewModels.BasketViewModels;

public class ResultBasketWithProductViewModel
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
    public decimal TotalPrice { get; set; }
    public string? ProductName{ get; set; }
    public int MenuTableId { get; set; }
}