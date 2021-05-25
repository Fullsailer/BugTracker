using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BugTracker.Models
{
    public class TicketAttachment
    {
        public int Id { get; set; }

        [DisplayName("File Description")]
        public string Description { get; set; }
        
        [DisplayName("File Date")]
        public DateTime Created { get; set; }
        
        [DisplayName("Ticket")]
        public int TicketId { get; set; }
        
        [DisplayName("Team Member")]
        public int UserId { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        public IFormFile FormFile { get; set; }

        public string FileName { get; set; }

        public byte[] FileData { get; set; }

        [DisplayName("File Extension")]
        public string FileContentType { get; set; }

        //-- Navigation
        public virtual Ticket Ticket { get; set; }

        public virtual BTUser User{ get; set; }
    }
}
