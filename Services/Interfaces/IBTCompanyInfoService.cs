using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Models;

namespace BugTracker.Services.Interfaces
{
    interface IBTCompanyInfoService
    {

            Task<Company> GetCompanyInfoByIdAsync(int? companyId);

            Task<List<BTUser>> GetAllMembersAsync(int companyId);

            Task<List<BTUser>> GetAllProjectsAsync(int companyId);

            Task<List<BTUser>> GetAllTicketsAsync(int companyId);

            Task<List<BTUser>> GetMembersInRoleAsync(string roleName, int companyId);
      

    }
}
