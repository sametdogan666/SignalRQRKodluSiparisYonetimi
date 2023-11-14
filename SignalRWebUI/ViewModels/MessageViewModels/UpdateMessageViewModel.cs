﻿namespace SignalRWebUI.ViewModels.MessageViewModels;

public class UpdateMessageViewModel
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Subject { get; set; }
    public DateTime SendDate { get; set; }
    public string? MessageContent { get; set; }
}