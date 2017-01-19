using System.Threading.Tasks;
using MegsoftBounty.Models.BeLazy;

namespace MegsoftBounty.Services.Slack
{
    public interface ISlackService 
    {
        Task PostSummaryToSlack(DailyStatus dailyStatus);
    }
}