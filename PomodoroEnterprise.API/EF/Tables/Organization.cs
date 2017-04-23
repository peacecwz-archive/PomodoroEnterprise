using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PomodoroEnterprise.API.EF.Tables
{
    public class Organization
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<User> Users { get; set; }
    }
}