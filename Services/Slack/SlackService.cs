using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MegsoftBounty.Models.BeLazy;
using MegsoftBounty.Models.Slack;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MegsoftBounty.Services.Slack 
{
    public class SlackService : ISlackService
    {
        public async Task PostSummaryToSlack(DailyStatus dailyStatus)
        {
            if (dailyStatus == null)
                throw new ArgumentNullException();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var slackRequest = new SlackRequestPayload {
                Text = dailyStatus.Summary,
                Icon_Url = @"https://ca.slack-edge.com/T02CRB87D-U02J1QEUM-161d7035d399-512",
                UserName = "@jgtaveras"
            };

            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.NullValueHandling = NullValueHandling.Ignore;

            var jsonSlackRequest = JsonConvert.SerializeObject(slackRequest,settings);

            var content = new StringContent(jsonSlackRequest, System.Text.Encoding.UTF8,"application/json");
            var response = await httpClient.PostAsync(dailyStatus.Project.SlackIntegrationUrl,content);
            response.EnsureSuccessStatusCode();

        }


    }
}