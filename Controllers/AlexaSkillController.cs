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
                        text = "You have 8,000 pesos left on your medical plan"
                    },
                    card = new {
                        type = "Simple",
                        title = "Be Lazy",
                        content = "You have 8,000 pesos left on your medical plan"
                    }
                },
                shouldEndSession = true
            };

            return response;
        }
    }
}