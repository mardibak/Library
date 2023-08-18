﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LibIdentity.DomainContracts.UserContracts;

public class LoginDto
{
    [Required]
    [Display(Name = "User Name / Email ")]
    public string Name { get; set; }

    [Required]
    [UIHint("Password")]
    public string Password { get; set; }

    [BindProperty(Name = "ReturnUrl", SupportsGet = true)]
    public string ReturnUrl { get; set; } = "/";

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
}
