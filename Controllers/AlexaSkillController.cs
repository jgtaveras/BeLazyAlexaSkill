using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using MegsoftBounty.Services.BeLazy;
using MegsoftBounty.Models.BeLazy;

namespace WebApplication.Controllers {

    public class AlexaSkillController : Controller {

        [HttpPost, Route("api/alexa/belazy")]
        public async Task<dynamic> BeLazy(dynamic body ){

            var service = new BeLazyService();
            
            await service.PostToSlack();

            var response = new {
                version = "1.0",
                sessionAttributes = new {},
                response = new {
                    outputSpeech = new {
                        type = "PlainText",
                        text = "Posting your daily status on Slack"
                    },
                    card = new {
                        type = "Simple",
                        title = "Be Lazy",
                        content = "Posting your daily status on Slack"
                    }
                },
                shouldEndSession = true
            };

            return response;
        }

        [HttpGet, Route("api/sources/harvest/harvestStatus")]
        public async Task<IEnumerable<DailyStatus>> HarvestStatus() {
            var service = new BeLazyService();

            var status = await service.GetDailyStatus();

            return status;
         
        }

        [HttpGet, Route("api/postStatus")]
        public async Task PostStatus(){
            var service = new BeLazyService();
            
            await service.PostToSlack();
        }
    } 
}