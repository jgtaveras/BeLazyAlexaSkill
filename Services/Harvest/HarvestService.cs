using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MegsoftBounty.Models.Harvest;
using Newtonsoft.Json;

namespace MegsoftBounty.Services.Harvest 
{
    public interface IHarvestService
    {
        Task<DailyEntries> GetDailyEntriesForUser();
    }

    public class HarvestService : IHarvestService
    {
        public async Task<DailyEntries> GetDailyEntriesForUser()
        {
            var httpClient = new HttpClient();
            var credentials = new HarvestCredentials("jose@megsoftconsulting.com","asDF1329cgg");
            
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic",credentials.Base64Encode());

            var endpointURL = $"https://megsoftconsulting.harvestapp.com/daily/{DateTime.Now.AddDays(-1).DayOfYear}/{DateTime.Now.Year}?slim=1";
            var response = await httpClient.GetAsync(endpointURL);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            
            var entries = JsonConvert.DeserializeObject<DailyEntries>(body);
            return entries;


        }
    }

}