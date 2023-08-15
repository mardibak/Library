﻿using LibIdentity.Domain.RoleAgg;
using LibIdentity.Domain.UserAgg;
using LibIdentity.DomainContracts.RoleContracts;
using LibIdentity.DomainContracts.UserContracts;
using Library.EndPoint.Areas.adminPanel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library.EndPoint.Areas.adminPanel.Controllers;
[Area("adminPanel")]
[Authorize(Roles = "admin")]

public class UsersController : Controller
{
    private readonly IUserService _userService;
    private readonly IRoleService _roleService;

    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    public UsersController(IUserService userService, IRoleService roleService,
        RoleManager<Role> roleManager, UserManager<User> userManager)
    {
        _userService = userService;
        _roleService = roleService;
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public async Task<ActionResult<List<UserWithRolesViewModel>>> Index()
    {
        var users = await _userService.GetAllUsers();
        return View(users);
    }

    [HttpGet]
    public async Task<ActionResult<UserViewModel>> Details(int id)
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

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }
        return RedirectToAction("Index");
    }



    public async Task<ActionResult> Update(int id)
    {
        var user = await _userService.GetUser(id);
        if (user == null)
        {
            return View("Error");
        }
        return View(user);
    }

    [HttpPost]
    public async Task<ActionResult<UserViewModel>> Update(UserViewModel user)
    {
        if (!ModelState.IsValid)
        {
            return View(user);
        }

        await _userService.Update(user);
        return RedirectToAction("Index");
    }

    public async Task<ActionResult> Delete(int id)
    {
        var user = await _userService.GetUser(id);
        if (id == 0 || user == null)
        {
            return NotFound();
        }

        return View(user);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
        if (ModelState.IsValid)
        {
            await _userService.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }
        return BadRequest();
    }

    public async Task<IActionResult> AssignRole()
    {
        var command = new UserRoleViewModel
        {
            Users = await _userService.GetAllUsers(),
            Roles = await _roleService.GetRoles(),
        };
        return View("AssignRole", command);
    }
    [HttpPost]
    public async Task<IActionResult> AssignRole(UserRoleViewModel model)
    {
        var user = await _userManager.FindByIdAsync(model.UserId.ToString());
        var role = await _roleManager.FindByIdAsync(model.RoleId.ToString());
        if (user == null || role == null)
        {
            return BadRequest();
        }

        if (await _userManager.IsInRoleAsync(user, role.Name))
        {
            ViewBag.RoleExistError = "User is already in the selected role.";
            //return RedirectToAction("AssignRole");
        }
        else
        {
            var result = await _userManager.AddToRoleAsync(user, role.ToString());
            if (result.Succeeded)
            {
                ViewBag.RoleAssigned = "Role assigned to User";
                return RedirectToAction("AssignRole");
            }
        }
        return RedirectToAction("AssignRole");
    }

    [HttpPost]
    public async Task<IActionResult> RemoveUserFromRole(int userId, string roleId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        var role = await _roleManager.FindByIdAsync(roleId);

        if (user == null || role == null)
        {
            return BadRequest();
        }

        var result = await _userManager.RemoveFromRoleAsync(user, role.Name);

        if (result.Succeeded)
        {
            return RedirectToAction("AssignRole");
        }

        return RedirectToAction("AssignRole");
    }

}