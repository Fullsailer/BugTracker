using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Data;
using BugTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Services.Interfaces
{
    public class BTTicketService : IBTTicketService
    {
        private readonly ApplicationDbContext _context;
        private readonly IBTRolesService _rolesService;
        private readonly IBTProjectService _Projectervice;

        public BTTicketService(ApplicationDbContext context,
            IBTRolesService rolesService, IBTProjectService Projectervice)
        {
            _context = context;
            _rolesService = rolesService;
            _Projectervice = Projectervice;
        }

        public async Task AssignTicketsAsync(int ticketId, string userId)
        {
            Ticket ticket = await _context.Ticket.FirstOrDefaultAsync(t => t.Id == ticketId);

            if (ticket != null)
            {
                try
                {
                    ticket.TicketStatusId = (await LookupTicketStatusIdAsync("Development")).Value;
                    ticket.DeveloperUserId = userId;
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public async Task<BTUser> GetTicketDeveloperAsync(int ticketId)
        {
            BTUser developer = new();

            Ticket ticket = await _context.Ticket.Include(t => t.DeveloperUser).FirstOrDefaultAsync(t => t.Id == ticketId);

            if (ticket?.DeveloperUserId != null)
            {
                developer = ticket.DeveloperUser;
            }

            return developer;
        }
        public async Task<List<Ticket>> GetAllTicketsByCompanyAsync(int companyId)
        {
            try
            {
                List<Ticket> tickets = await _context.Project.Include(p => p.Company).Where(p => p.CompanyId == companyId)
                                                                .SelectMany(p => p.Tickets)
                                                                    .Include(t => t.Attachments)
                                                                    .Include(t => t.Comments)
                                                                    .Include(t => t.History)
                                                                    .Include(t => t.DeveloperUser)
                                                                    .Include(t => t.OwnerUser)
                                                                    .Include(t => t.TicketPriority)
                                                                    .Include(t => t.TicketStatus)
                                                                    .Include(t => t.TicketType)
                                                                    .Include(t => t.Project)
                                                                    .ToListAsync();
                return tickets;
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<Ticket>> GetArchivedTicketsByCompanyAsync(int companyId)
        {
            try
            {
                List<Ticket> tickets = await _context.Project.Where(p => p.CompanyId == companyId)
                                                                .SelectMany(p => p.Tickets)
                                                                    .Include(t => t.Attachments)
                                                                    .Include(t => t.Comments)
                                                                    .Include(t => t.DeveloperUser)
                                                                    .Include(t => t.OwnerUser)
                                                                    .Include(t => t.TicketPriority)
                                                                    .Include(t => t.TicketStatus)
                                                                    .Include(t => t.TickeType)
                                                                    .Include(t => t.Project)
                                                                    .Where(t => t.Archived == true)
                                                                    .ToListAsync();
                return tickets;
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<Ticket>> GetAllTicketsByPriorityAsync(int companyId, string priorityName)
        {
            int priorityId = (await LookupTicketPriorityIdAsync(priorityName)).Value;
            List<Ticket> ticket = new();

            try
            {
                tickets = await _context.Project.Where(p => p.CompanyId == companyId)
                                                .SelectMany(p => p.Tickets)
                                                    .Include(t => t.Attachments)
                                                    .Include(t => t.Comments)
                                                    .Include(t => t.DeveloperUser)
                                                    .Include(t => t.OwnerUser)
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
            return ticket;
        }

        public async Task<List<Ticket>> GetAllPMTicketsAsync(string userId)
        {
            throw new NotImplementedException();
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


        public async Task<List<Ticket>> GetProjectTicketsByRoleAsync(string role, string userId, int projectId)
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
