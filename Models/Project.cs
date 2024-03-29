﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BugTracker.Models
{
    public class Project
    {
        public int Id { get; set; }

        [DisplayName("Company")]
        public int? CompanyId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("ProjectName")]
        public string Name { get; set; }
        
        [DisplayName("Description")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        public DateTimeOffset StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("End Date")]
        public DateTimeOffset? EndDate { get; set; }

        [DisplayName("Priority")]
        public int? ProjectPriorityId { get; set; }
       
        
        [NotMapped]
        [DataType(DataType.Upload)]
        //[MaxFileSixe(1024 *1024]
        //[AllowedExtensions(new string [] {".jpg", ".png" })]

        public IFormFile ImageFormFile { get; set; }

        [DisplayName("File Name")]

        public string ImageFileName { get; set; }

        public byte[] ImageFileData { get; set; }

        [DisplayName("File Extention")]
        public string ImageContentType { get; set; }

        [DisplayName("Archived")]
        public bool Archived { get; set; }



            //-- Navigation properties --

        public virtual Company Company { get; set; }
        public virtual ProjectPriority ProjectPriority { get; set; }
        public virtual ICollection<BTUser> Members { get; set; } = new HashSet<BTUser>();
        public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();

    }
}
