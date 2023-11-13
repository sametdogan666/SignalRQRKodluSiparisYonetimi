﻿using Microsoft.AspNetCore.Identity;

namespace SignalR.Entities.Entities;

public class AppUser : IdentityUser<int>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}