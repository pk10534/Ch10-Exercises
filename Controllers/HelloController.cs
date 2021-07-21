using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chap_10_exercise.Controllers
{
    [Route("/helloworld")]
    public class HelloController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        //[Route("/helloworld")]
        public IActionResult Index()
        {
            string html = "<form method='post' action='/helloworld/language'>" +
                "<input type='text' name='name' />" +
             "<select name='language' id='lang-select'>" +
                "<option value='English'>English</option>" +
                "<option value='French'>French</option>" +
                "<option value='Spanish'>Spanish</option>" + "</select>" +
                "<input type='submit' value='Greet Me!' />" +
                "</form>";
            return Content(html, "text/html");
        }

        // GET: /<controller>/welcome
        //[HttpGet("welcome/{name?}")]
        [HttpPost("welcome")]
        public IActionResult Welcome(string name = "World")
        {
            return Content("<h1>Welcome to my app, " + name + "!</h1>", "text/html");
        }

        [HttpPost("language")]
        public ActionResult<string> Language(LanguageRequest request)
        {
            try
            {
                var translation = Translate(request.Name, request.Language);
                var markUp = "<h1>" + translation + "</h1>";
                return Content(markUp, "text/html");
            }
            catch
            {
                return BadRequest();
            }
        }

        private string Translate(string name, string language)
        {
            return language switch
            {
                "English" => "Hello, " + name,
                "French" => "Bonjour, " + name,
                "Spanish" => "Hola, " + name,
                _ => throw new NotImplementedException(language),
            };
        }
    }

    public class LanguageRequest
    {
        public string Name { get; set; }
        public string Language { get; set; }
    }
}
