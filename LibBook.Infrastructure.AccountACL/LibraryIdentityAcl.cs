﻿using LibBook.Domain.Services;
using LibIdentity.DomainContracts.UserContracts;

namespace LibBook.Infrastructure.AccountACL;

public class LibraryIdentityAcl : ILibraryIdentityAcl
{
    private readonly IUserService _userService;

    public LibraryIdentityAcl(IUserService userService)
    {
        _userService = userService;
    }

    public (string name, string email) GetAccountBy(int id)
    {
        var account = _userService.GetAccountBy(id);
        return (account.FirstName, account.Email);
    }
    public async Task<string> GetUserName(string id)
    {
        var userName = await _userService.GetUserNameByIdAsync(id);
        return userName;
    }
}