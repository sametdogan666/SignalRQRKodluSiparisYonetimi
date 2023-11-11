namespace SignalRWebUI.ViewModels.BasketViewModels;

public class ResultBasketViewModel
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
    public decimal TotalPrice { get; set; }
    public int ProductId { get; set; }
    public int MenuTableId { get; set; }
}