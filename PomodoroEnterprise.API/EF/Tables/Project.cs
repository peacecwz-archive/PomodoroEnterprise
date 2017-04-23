using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PomodoroEnterprise.API.EF.Tables
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public virtual User User { get; set; }
    }
}