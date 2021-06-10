using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Extensions;
using BugTracker.Models;
using BugTracker.Models.ViewModels;
using BugTracker.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BugTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<BTUser> _userManager;
        private readonly IBTCompanyInfoService _companyInfoService;
        private readonly IBTProjectService _projectService;
        private readonly IBTTicketService _ticketService;

        public HomeController(ILogger<HomeController> logger,
                                UserManager<BTUser> userManager,
                                IBTCompanyInfoService companyInfoService,
                                IBTProjectService projectService,
                                IBTTicketService ticketService)
        {
            _logger = logger;
            _userManager = userManager;
            _companyInfoService = companyInfoService;
            _projectService = projectService;
            _ticketService = ticketService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Landing()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Dashboard()
        {
            int companyId = User.Identity.GetCompanyId().Value;

            DashboardViewModel model = new()
            {
                Companies = await _companyInfoService.GetCompanyInfoByIdAsync(companyId),
                Projects = await _projectService.GetAllProjectsByCompany(companyId),
                Tickets = await _ticketService.GetAllTicketsByCompanyAsync(companyId),
                Members = await _companyInfoService.GetAllMembersAsync(companyId)
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
