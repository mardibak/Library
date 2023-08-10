﻿using AutoMapper.Execution;
using LibBook.DomainContracts.Borrow;
using LibIdentity.Domain.UserAgg;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library.EndPoint.Areas.adminPanel.Controllers;

[Area("adminPanel")]
public class HomeController : Controller
{
    private readonly IBorrowService _borrowService;
    private readonly UserManager<User> _userManager;
    public HomeController(IBorrowService borrowService, UserManager<User> userManager)
    {
        _borrowService = borrowService;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> Details()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToAction("Login", "Account","adminPanel");
        }

        var result = await _borrowService.GetBorrowsByMemberId(user.Id.ToString());
        return View("Details", result);
    }
    [HttpGet]

    public async Task<IActionResult> Borrows(string memberId)
    {
        var result = await _borrowService.GetBorrowsByMemberId(memberId);
        return View("Borrows", result);
    }
    public IActionResult Profile()
    {
        return View();
    }
}