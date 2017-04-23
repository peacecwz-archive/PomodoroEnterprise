using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroEnterprise.Mobile.Models
{
    public class SettingsModel
    {
        public int LongPomodorTime { get; set; } = 25;
        public int ShortPomodorTime { get; set; } = 5;
        public int PeriodPomodorTime { get; set; } = 30;
        public int PeriodPomodorCount { get; set; } = 4;
        public bool IsQuiet { get; set; } = true;
    }
}
