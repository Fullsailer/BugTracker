﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BugTracker.Models.ViewModels
{
    public class ManageUserRolesViewModel
    {
        public BTUser BTUser { get; set; } = new();
        public MultiSelectList Roles { get; set; }
        public List<string> SelectedRoles { get; set; }
    }
}
