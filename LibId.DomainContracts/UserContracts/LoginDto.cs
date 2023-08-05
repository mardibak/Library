﻿using System.ComponentModel.DataAnnotations;

namespace LibIdentity.DomainContracts.UserContracts;

public class LoginDto
{
    [Required]
    [Display(Name = "User Name / Email ")]
    public string Name { get; set; }

    [Required]
    [UIHint("Password")]
    public string Password { get; set; }

    public string ReturnUrl { get; set; } = "/";

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
}
