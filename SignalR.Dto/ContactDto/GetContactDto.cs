namespace SignalR.Dto.ContactDto;

public class GetContactDto
{
    public int Id { get; set; }
    public string? Location { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? FooterDescription { get; set; }
}