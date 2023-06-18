﻿using AutoMapper;
using LI.ApplicationContracts.RoleContracts;
using LI.Domain.RoleAgg;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LI.ApplicationServices;

public class RoleService : IRoleService
{
    private readonly RoleManager<Role> _roleManager;

    private readonly IMapper _mapper;

    public RoleService(RoleManager<Role> roleManager, IMapper mapper)
    {
        _roleManager = roleManager;
        _mapper = mapper;
    }
    #region Get
    public async Task<RoleDto> GetRole(string id)
    {
        var role = await _roleManager.FindByIdAsync(id);
        return _mapper.Map<RoleDto>(role);
    }
    #endregion

    #region GetAll
    public async Task<List<RoleDto>> GetRoles()
    {
        List<Role> roles = await _roleManager.Roles.Take(50).ToListAsync();
        return _mapper.Map<List<RoleDto>>(roles);
    }
    #endregion

    #region Create
    public async Task<IdentityResult> CreateRole(RoleDto model)
    {
        var roleMap = _mapper.Map<Role>(model);
        return await _roleManager.CreateAsync(roleMap);
    }
    #endregion

    #region Update
    public async Task<IdentityResult> UpdateRole(RoleDto role)
    {
        var result = await _roleManager.FindByIdAsync(role.Id.ToString());
        result.Name = role.Name;

        return await _roleManager.UpdateAsync(result);
    }
    #endregion

    #region Delete
    public async Task<IdentityResult> DeleteRole(RoleDto dto)
    {
        var role = await _roleManager.FindByIdAsync(dto.Id.ToString());
        var roleMap = _mapper.Map<Role>(role);
        return await _roleManager.DeleteAsync(roleMap);
    }
    #endregion
}
