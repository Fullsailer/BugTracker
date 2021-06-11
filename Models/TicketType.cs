using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
   
    public class TicketType
    {

        //Primary Key
        public int Id { get; set; }
        
        [DisplayName("Ticket Type")]
        public string Name { get; set; }

        public string Company { get; set; }

        public string Project { get; set; }

        public string Invitor { get; set; }
        public Guid CompanyToken { get; set; }
        public string InviteeEmail { get;  set; }
        public DateTime InviteDate { get; set; }
        public bool IsValid { get; set; }
    }
}
