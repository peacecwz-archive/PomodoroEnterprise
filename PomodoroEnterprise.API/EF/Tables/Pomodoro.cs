using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PomodoroEnterprise.API.EF.Tables
{
    public class Pomodoro
    {
        [Key]
        public int Id { get; set; }
        public bool IsSuccess { get; set; }
        public int TaskId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public virtual Task Task { get; set; }
    }
}