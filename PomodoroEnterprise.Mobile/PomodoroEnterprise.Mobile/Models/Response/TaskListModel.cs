using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroEnterprise.Mobile.Models.Response
{
    public class TaskListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSuccess { get; set; }
        public int ProjectId { get; set; }
        public DateTime Deadline { get; set; }
    }
}
