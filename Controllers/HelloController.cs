using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch10_Exercises.Controllers
{
    [Route("/helloworld")]
    public class HelloController : Controller
    {
        [HttpGet]
        //[Route("/helloworld")] <-- not needed anymore bc route added above
        public IActionResult Index() 
        {
            string html = "<form method='post' action='/helloworld/welcome'>" +
            "<input type='text' name='name' />" + "<input type='submit' value='Greet Me!' />" + "</form>";
            return Content(html, "text/html");
        }

        [HttpGet("welcome/{name?}")]
        [HttpPost("welcome")]
        //[Route("/helloworld/welcome")] 
        public IActionResult Welcome(string name="World") //world is optional parameter or welome?name="Patrick"
        {
            return Content("<h1>Welcome to my app, " + name + "!</h1>", "text/html");
        }

        [HttpGet]
        public IActionResult Language()
        {
            string html2 = "form method='post' action='/helloworld/welcome'>" + "<input type='text' name='name' />" +
                "<select name='Language' id='lang-select'>" +
                "<option value='hello'>English</option>" +
                "<option value='hola'>Spanish</option>" +
                "<option value='Privet'>Russian</option>" +
                "<option value='hallo'>Norwegian</option>" +
                "<option value='marhaban'>Arabic</option>";
                return Content(html2, "text, html");

        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
