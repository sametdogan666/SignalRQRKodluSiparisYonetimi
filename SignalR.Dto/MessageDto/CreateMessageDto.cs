namespace SignalR.Dto.MessageDto;

public class CreateMessageDto
{
    public string? FullName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Subject { get; set; }
    public string? MessageContent { get; set; }
}