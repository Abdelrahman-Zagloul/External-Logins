﻿using Microsoft.AspNetCore.Identity;

namespace External_Logins.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string? FullName { get; set; }
    }
}
