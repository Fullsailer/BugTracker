using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Models;

namespace BugTracker.Services.Interfaces
{
    public interface IBTTIcketService
    {
        Task AssignTicketAsync(int ticketId, string userId);
        Task<BTUser> GetTicketDeveloperAsync(int ticketId);

    }
}
