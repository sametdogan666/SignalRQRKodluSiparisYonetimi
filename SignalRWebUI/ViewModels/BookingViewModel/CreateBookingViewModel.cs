namespace SignalRWebUI.ViewModels.BookingViewModel;

public class CreateBookingViewModel
{
    public string? FullName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public int PersonCount { get; set; }
    public DateTime Date { get; set; }
}