using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers {

    public class AlexaSkillController : Controller {

        [HttpPost, Route("api/alexa/belazy")]
        public dynamic BeLazy(dynamic body ){
            var response = new {
                version = "1.0",
                sessionAttributes = new {},
                response = new {
                    outputSpeech = new {
                        type = "PlainText",
                        text = "Trying to post this to slack"
                    },
                    card = new {
                        type = "Simple",
                        title = "Be Lazy",
                        content = "Trying to post this to \nslack"
                    }
                },
                shouldEndSession = true
            };

            return response;
        }
    }
}