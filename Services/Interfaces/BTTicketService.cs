using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Models;

namespace BugTracker.Services.Interfaces
{
    public class BTTicketService : IBTTicketService
    {
        public async Task AssignTicketAsync(int ticketId, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Ticket>> GetAllPMTicketsAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Ticket>> GetAllTicketsByCompanyAsync(int companyId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Ticket>> GetAllTicketsByPriorityAsync(int companyId, string priorityName)
        {
            int priorityId = (await LookupTicketPriorityIdAsync(priorityName)).Value;
            List<Ticket> ticket = new();

            try
            {
                tickets = await _context.Project.Where(p => p.CompanyId == companyId)
                                                .SelectMany(p => p.Tickets)
                                                    .Include(t => t.Attchments)
                                                    .Include(t => t.Comments)
                                                    .Include(t => t.DeveloperUser)
                                                    .Include(t => t.OnwerUser)
                                                    .Include(t => t.TicketPriority)
                                                    .Include(t => t.TicketStatus)
                                                    .Include(t => t.TicketType)
                                                    .Include(t => t.Project)
                                                .Where(t => t.TicketPriorityId == priorityId).ToListAsync();
            }
            catch
            {
                throw;
            }
            return tickets;
        }

        public async Task<List<Ticket>> GetAllTicketsByRoleAsync(string role, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Ticket>> GetAllTicketsByStatusAsync(int companyId, string statusName)
        {
            int statusId = (await LookupTicketStatusIdAsync(statusName)).Value;
            return await _context.Project.Where(p => p.CompanyId == companyId)
                                        .SelectMany(p => p.Tickets)
                                        .Where(t => t.TicketStatusId == statusId).ToListAsync();
        }

        public async Task<List<Ticket>> GetAllTicketsByTypeAsync(int companyId, string typeName)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Ticket>> GetArchivedTicketsByCompanyAsync(int companyId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Ticket>> GetProjectTicketsByRoleAsync(string role, string userId, int projectId)
        {
            throw new NotImplementedException();
        }

        public async Task<BTUser> GetTicketDeveloperAsync(int ticketId)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> LookupTicketPriorityIdAsync(string priorityName)
        {
            return (await _context.TicketPriority.FirstOrDefaultAsync(p => p.Name == priorityName)).Id;
        }

        public async Task<int?> LookupTicketStatusIdAsync(string statusName)
        {
            try
            {
                TicketStatus status = await _context.TicketStatus.FirstOrDefaultAsync(p => p.Name == statusName);
                return status?.Id;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int?> LookupTicketTypeIdAsync(string typeName)
        {
            return (await _context.TicketType.FirstOrDefaultAsync(p => p.Name == typeName)).Id;
        }
    }
}
