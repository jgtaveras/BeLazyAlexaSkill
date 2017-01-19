using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegsoftBounty.Models.BeLazy;
using MegsoftBounty.Services.Harvest;
using MegsoftBounty.Services.Slack;

namespace MegsoftBounty.Services.BeLazy 
{
    public class BeLazyService 
    {
        private readonly IHarvestService _harvestService;
        private readonly ISlackService _slackService;

        public BeLazyService()
        {
            _harvestService = new HarvestService();
            _slackService = new SlackService();
        }

        public async Task<IEnumerable<DailyStatus>> GetDailyStatus() {
            
            var harvestEntries = await _harvestService.GetDailyEntriesForUser();

            var dailyStatus = from e in harvestEntries.day_entries group e by e.project into g
            select new DailyStatus {
                Project = new Project {
                    Name = g.Key,
                    SlackIntegrationUrl = "https://hooks.slack.com/services/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"
                },
                Tasks = g.Select (p => new DailyTask {
                    Name = $"{p.task} {p.notes}",
                    Activities = new List<DailyTaskActivity> {
                            new DailyTaskActivity {
                                Source = "Harvest",
                                Summary = $"{p.notes}"
                            }
                    }
                }).ToList()
            };


            return dailyStatus;

        }

        public async Task PostToSlack()
        {
            var projectsStatus = await GetDailyStatus();

            foreach(var status in projectsStatus)
            {
                await _slackService.PostSummaryToSlack(status);
            }

        }
    }

}