using Microsoft.AspNetCore.Mvc;

namespace MenaxhimiGjendjes.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Test()
        {
            return Content("Ja dola");
        }
        public IActionResult Kerkese(string emer, string vendlindja)
        {
            return Content("Emer: "+emer + " Vendlindja: " + vendlindja);
        }
    }
}
