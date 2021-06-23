﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models.ViewModels
{
    public class DashboardViewModel
    {
        public List<Project> Projects { get; set; }

        public List<Ticket> DevelopmentTickets { get; set; }

        public List<Ticket> SubmittedTickets { get; set; }

        public List<Ticket> Tickets { get; set; }

        public List<BTUser> Members { get; set; }

        public BTUser CurrentUser { get; set; }

        public Company Company { get; set; }
        
    }
}
