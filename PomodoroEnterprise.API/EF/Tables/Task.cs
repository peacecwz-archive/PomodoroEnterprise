using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PomodoroEnterprise.API.EF.Tables
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public int ProjectId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public virtual Project Project { get; set; }
    }
}