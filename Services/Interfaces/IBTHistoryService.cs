﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Models;

namespace BugTracker.Services.Interfaces
{
    public interface IBTHistoryService
    {
        Task AddHistoryAsync(Ticket oldTicket, Ticket newTicket, string userId);

        Task<List<TicketHistory>> GetProjectTicketsHistoriesAsync(int projectId);

        Task<List<TicketHistory>> GetCompanyTicketsHistoriesAsync(int companyId);

    }

}
