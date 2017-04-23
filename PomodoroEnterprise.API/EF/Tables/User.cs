using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PomodoroEnterprise.API.EF.Tables
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int? OrganizationId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public virtual List<Project> Projects { get; set; }
        public virtual Organization Organization { get; set; }
    }
}