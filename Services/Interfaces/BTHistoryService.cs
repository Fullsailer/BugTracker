using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Data;
using BugTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Services.Interfaces
{
    public class BTHistoryService : IBTHistoryService
    {
        private readonly ApplicationDbContext _context;

        public BTHistoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddHistoryAsync(Ticket oldTicket, Ticket newTicket, string userId)
        {
            //New Ticket has been added
           if(oldTicket == null && newTicket != null)
            {
                TicketHistory history = new()
                {
                    TicketId = newTicket.Id,
                    Property = "",
                    OldValue = "",
                    NewValue = "New Ticket",
                    Created = DateTimeOffset.Now,
                    UserId = userId,
                    Description = "New Ticket Created"
                };
                await _context.TicketHistory.AddAsync(history);
                await _context.SaveChangesAsync();
            }
            else
            {
                if (oldTicket.Title != newTicket.Title)
                if (oldTicket.Description != newTicket.Description)
                if (oldTicket.TicketTypeId != newTicket.TicketTypeId)
                if (oldTicket.TicketPriorityId != newTicket.TicketPriorityId)
                if(oldTicket.TicketStatusId != newTicket.TicketStatusId)
                if (oldTicket.DeveloperUserId != newTicket.DeveloperUserId)
                                    {
                    TicketHistory history = new()
                    {
                        TicketId = newTicket.Id,
                        Property = "Title",
                        OldValue = oldTicket.Title,
                        NewValue = newTicket.Title,
                        Created = DateTimeOffset.Now,
                        UserId = userId,
                        Description = $"New ticket title: {newTicket.Title}"
                    };
                    await _context.TicketHistory.AddAsync(history);
                }
                if (oldTicket.Description != newTicket.Description)
                {
                    TicketHistory history = new()
                    {
                        TicketId = newTicket.Id,
                        Property = "Description",
                        OldValue = oldTicket.Description,
                        NewValue = newTicket.Description,
                        Created = DateTimeOffset.Now,
                        UserId = userId,
                        Description = $"New ticket description: {newTicket.Description}"
                    };
                    await _context.TicketHistory.AddAsync(history);

                }
                if (oldTicket.TicketTypeId != newTicket.TicketTypeId)
                {
                    TicketHistory history = new()
                    {
                        TicketId = newTicket.Id,
                        Property = "Type",
                        OldValue = oldTicket.TicketType,
                        NewValue = newTicket.TicketType,
                        Created = DateTimeOffset.Now,
                        UserId = userId,
                        Description = $"New ticket Type: {newTicket.TicketType}"
                    };
                    await _context.TicketHistory.AddAsync(history);

                }
                if (oldTicket.TicketPriorityId != newTicket.TicketPriorityId)
                {
                    TicketHistory history = new()
                    {
                        TicketId = newTicket.Id,
                        Property = "Priority",
                        OldValue = oldTicket.TicketPriority,
                        NewValue = newTicket.TicketPriority,
                        Created = DateTimeOffset.Now,
                        UserId = userId,
                        Description = $"New ticket priority: {newTicket.TicketPriority}"
                    };
                    await _context.TicketHistory.AddAsync(history);

                }
                if (oldTicket.TicketStatusId != newTicket.TicketStatusId)
                {
                    TicketHistory history = new()
                    {
                        TicketId = newTicket.Id,
                        Property = "Status",
                        OldValue = oldTicket.TicketStatus,
                        NewValue = newTicket.TicketStatus,
                        Created = DateTimeOffset.Now,
                        UserId = userId,
                        Description = $"New ticket status: {newTicket.TicketStatus}"
                    };
                    await _context.TicketHistory.AddAsync(history);

                
                    if (oldTicket.DeveloperUserId != newTicket.DeveloperUserId)
                {
                    TicketHistory history = new()
                    {
                        TicketId = newTicket.Id,
                        Property = "DeveloperUser",
                        OldValue = oldTicket.DeveloperUser?.FullName ?? "Not Assigned",
                        NewValue = newTicket.DeveloperUser?.FullName,
                        Created = DateTimeOffset.Now,
                        UserId = userId,
                        Description = $"New ticket developer: {newTicket.DeveloperUser.FullName}"
                    };
                    await _context.TicketHistory.AddAsync(history);

                }
                    //Save the TicketHistory DataBaseSet
                    await _context.SaveChangesAsync();

            }

        public async Task<List<TicketHistory>> GetCompanyTicketsHistoriesAsync((int companyId)
        {
            Company company = await _context.Company
                                            .Include(c => c.Projects)
                                                .ThenInclude(p => p.Tickets)
                                                    .ThenInclude(t => t.History)
                                            .FirstOrDefaultAsync(c => c.Id == companyId);

            List<Ticket> tickets = company.Projects.SelectMany(p => p.Tickets).ToList();

            List<TicketHistory> ticketHistories = tickets.SelectMany(t => t.History).ToList();

            return ticketHistories;
        }

        public async Task<List<TicketHistory>> GetProjectTicketsHistoriesAsync((int projectId)
        {
            Project project = await _context.Project
                                            .Include(p => p.Tickets)
                                                  .ThenInclude(t => t.History)
                                            .FirstOrDefaultAsync(p => p.Id == projectId);
            List<TicketHistory> ticketHistory = project.Tickets.SelectMany(t => t.History).ToList();

            return ticketHistory;
        }
    }
}
