﻿namespace SignalR.Dto.ProductDto;

public class UpdateProductDto
{
    public int Id { get; set; }
    public string? ProductName { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public bool Status { get; set; }
    public int CategoryId { get; set; }
}