﻿namespace AlternativeEnergy.Infrastructure.Identity.Models
{
    public sealed class LoginModel
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}