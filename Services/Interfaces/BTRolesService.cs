﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Data;
using BugTracker.Models;
using Microsoft.AspNetCore.Identity;

namespace BugTracker.Services.Interfaces
{
    public class BTRolesService : IBTRolesService
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<BTUser> _userManager;

        public BTRolesService(ApplicationDbContext context,
           RoleManager<IdentityRole> roleManager,
           UserManager<BTUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public Task<bool> AddUserToRoleAsync(BTUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRoleNameByIdAsync(string roldeId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsUserInRoleAsync(BTUser user, string roleName)
        {
            bool result = await _userManager.IsInRoleAsync(user, roleName);
            return result;
        }

        public Task<IEnumerable<string>> ListUserRolesAsync(BTUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveUserFromRoleAsync(BTUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<List<BTUser>> UsersNotInRoleAsync(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
