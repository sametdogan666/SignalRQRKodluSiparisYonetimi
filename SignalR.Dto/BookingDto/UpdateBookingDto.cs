namespace SignalR.Dto.BookingDto;

public class UpdateBookingDto
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? Description { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public int PersonCount { get; set; }
    public DateTime Date { get; set; }
}