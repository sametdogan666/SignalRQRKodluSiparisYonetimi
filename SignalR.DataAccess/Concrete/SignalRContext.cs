﻿using Microsoft.EntityFrameworkCore;
using SignalR.Entities.Entities;

namespace SignalR.DataAccess.Concrete;

public class SignalRContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-LVPTDQG\SQLEXPRESS; initial catalog= SignalRQRDb; integrated security = true");
    }

    public DbSet<About>? Abouts { get; set; }
    public DbSet<Booking>? Bookings { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Contact>? Contacts { get; set; }
    public DbSet<Discount>? Discounts { get; set; }
    public DbSet<Feature>? Features { get; set; }
    public DbSet<Product>? Products { get; set; }
    public DbSet<SocialMedia>? SocialMedias { get; set; }
    public DbSet<Testimonial>? Testimonials { get; set; }

}