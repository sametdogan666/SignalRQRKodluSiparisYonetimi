﻿namespace SignalRWebUI.ViewModels.ContactViewModels;

public class UpdateContactViewModel
{
    public int Id { get; set; }
    public string? Location { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? FooterDescription { get; set; }
}