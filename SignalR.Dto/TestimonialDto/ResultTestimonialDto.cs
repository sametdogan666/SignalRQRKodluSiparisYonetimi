﻿namespace SignalR.Dto.TestimonialDto;

public class ResultTestimonialDto
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? Title { get; set; }
    public string? Comment { get; set; }
    public string? ImageUrl { get; set; }
    public bool Status { get; set; }
}