using System.Collections.Generic;

namespace MegsoftBounty.Models.Harvest 
{
    public class DailyEntries
    {
        public string for_day { get; set; }
        public List<DayEntry> day_entries { get; set; }
    }
}