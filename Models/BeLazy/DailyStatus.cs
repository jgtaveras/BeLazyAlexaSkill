using System.Collections.Generic;

namespace MegsoftBounty.Models.BeLazy
{
    public class DailyStatus 
    {
        public Project Project {get;set;}
        public List<DailyTask> Tasks{get;set;}
        public string Summary => BuildSummary();

        public DailyStatus()
        {
            Tasks = new List<DailyTask>();
        }


        private string BuildSummary() 
        {
            var statusSummary = "";

            foreach(var task in Tasks)
            {
                statusSummary += $"{task.Name}";
                foreach(var activity in task.Activities)
                {
                    statusSummary += $"{activity.Summary}";
                }
            }

            return statusSummary;
        }
    }
}
