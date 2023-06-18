﻿using LI.ApplicationContracts.UserContracts;
using Microsoft.AspNetCore.Mvc;

namespace Library.EndPoint.Areas.adminPanel.Controllers;
[Area("adminPanel")]
public class UsersController : Controller
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<ActionResult<List<UpdateUserDto>>> Index()
    {
        var users = await _userService.GetUsers();
        return View(users);
    }

    [HttpGet]
    public async Task<ActionResult<UpdateUserDto>> Details(string id)
    {
        var user = await _userService.GetUser(id);
        return View(user);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(UserDto model)
    {
        if (!ModelState.IsValid)
        {
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                var errorMessage = error.ErrorMessage;
                var exception = error.Exception;
            }
        }
        var result = await _userService.CreateUser(model);
        return RedirectToAction("Index");
    }


    public async Task<ActionResult> Update(string id)
    {
        var user = await _userService.GetUser(id);
        if (user == null)
        {
            return View("Error");
        }
        return View(user);
    }

    [HttpPost]
    public async Task<ActionResult<UpdateUserDto>> Update(UpdateUserDto user)
    {
        if (!ModelState.IsValid)
        {
            return View(user);
        }

        await _userService.Update(user);
        return RedirectToAction("Index");
        //return View(_mapper.Map<UpdateUserDto>(result));

    }

    public async Task<ActionResult> Delete(string id)
    {
        var user = await _userService.GetUser(id);
        if (id == null || user == null)
        {
            return NotFound();
        }

        return View(user);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(string id)
    {
        if (ModelState.IsValid)
        {
            await _userService.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }
        return BadRequest();
    }
}