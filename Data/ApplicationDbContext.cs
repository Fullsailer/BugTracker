﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using BugTracker.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static BugTracker.Data.DataUtilityClass;

namespace BugTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext<BTUser>
    {
        private readonly IConfiguration Configuration;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql(
                    DataUtility.GetConnectionString(Configuration),
            o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
        }

            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Company> Company { get; set; }
        public DbSet<Invite> Invite { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectPriority> ProjectPriority { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<TicketAttachment> TicketAttachment { get; set; }
        public DbSet<TicketComment> TicketComment { get; set; }
        public DbSet<TicketHistory> TicketHistory { get; set; }
        public DbSet<TicketPriority> TicketPriority { get; set; }
        public DbSet<TicketStatus> TicketStatus { get; set; }
        public DbSet<TicketType> TicketType { get; set; }
    }
}
