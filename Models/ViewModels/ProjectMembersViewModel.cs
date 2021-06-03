using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BugTracker.Models.ViewModels
{
    public class ProjectMembersViewModel
    {
        public Project Project { get; set; } = new();
        public MultiSelectList Users { get; set; } //populates list box
        public string[] SelectedUsers { get; set; } // recives selected users
    }
}
