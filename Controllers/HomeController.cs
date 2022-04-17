using MenaxhimiGjendjes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MenaxhimiGjendjes.Controllers
{
    public class HomeController : Controller
    {
        private string? preference;
        
        public IActionResult TestIn()
        {
            TempData["Info"] = "Test per transport!";
            return RedirectToAction("Index", "About");
           
        }

        public IActionResult Index()

        {
            if (!String.IsNullOrEmpty(Request.Cookies["Preferenca"]))
            {
                preference = Request.Cookies["Preferenca"];
                
            }
            else
            {
                return View("Forma");
            }
           
            return View("Index",preference);
        }
        public IActionResult FormaTeDhenaPersonale()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FormaTeDhenaPersonale(Guest guest)
        {
            HttpContext.Session.SetString("Email", guest.Email);
            HttpContext.Session.SetString("Username", guest.Username);
            HttpContext.Session.SetInt32("Mosha", (int)guest.Mosha);
            return RedirectToAction("Profil");
        }

        public IActionResult Profil()
        {
            var guest = new Guest
            {
                Email = HttpContext.Session.GetString("Email"),
                Username=HttpContext.Session.GetString("Username"),
                Mosha=HttpContext.Session.GetInt32("Mosha")

               
        };

            return View(guest);

        }
        public IActionResult Pastro()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Profil");
        }

        public IActionResult Forma()
        {
            return View();
        }



        [HttpPost]
        public IActionResult RuajPreference(IFormCollection form )
        {
            if (!String.IsNullOrEmpty(form["preference"])){

                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddHours(1);
                options.Secure = true;
                Response.Cookies.Append("Preferenca", form["preference"], options);
            }
           

            return RedirectToAction("Index");
        }
       
        public IActionResult HiqPreference()
        {
            Response.Cookies.Delete("Preferenca");
            return RedirectToAction("Index");   
        }
        public IActionResult Privacy()
        {
            return View();
        }

      
    }
}