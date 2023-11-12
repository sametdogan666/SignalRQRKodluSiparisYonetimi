namespace SignalRWebUI.ViewModels.NotificationViewModels;

public class UpdateNotificationViewModel
{
    public int Id { get; set; }
    public string? Type { get; set; }
    public string? Icon { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public bool Status { get; set; }
}