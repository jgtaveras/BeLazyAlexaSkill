using System.Collections.Generic;

namespace MegsoftBounty.Models.BeLazy
{
     public class DailyTask
    {
        public string Name { get; set; }

        public List<DailyTaskActivity> Activities{get; set;}

        public DailyTask()
        {
            Activities = new List<DailyTaskActivity>();
        }
    }

    public class DailyTaskActivity
    {
        public string Source {get; set; }
        public string Summary { get; set; }
    }
}