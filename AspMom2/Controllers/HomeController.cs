using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspMom2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AspMom2.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            ViewData["Title"] = "Restaurang Esther";
            return View();
        }

        [HttpGet("/meny")]
        public IActionResult Menu()
        {
            //Läs in JSON-fil
            var JsonStr = System.IO.File.ReadAllText("appetizer.json");
            //Gör om object i JSON-filen till objekt från modellen.
            var JsonObj = JsonConvert.DeserializeObject<IEnumerable<Appetizer>>(JsonStr);
            ViewBag.Text = "Meny";
            return View(JsonObj);
        }

        [HttpGet("/bokabord")]
        public IActionResult BookTable()
        {
            ViewData["Title"] = "Boka bord";
            return View();
        }
        [HttpPost("/bokabord")]
        public IActionResult BookTable(IFormCollection col)
        {
            if (ModelState.IsValid)
            {
                //Instans av modellen
                BookTable booking = new BookTable();
                //Lagrar inputs i modellens properties
                booking.Name = col["Name"];
                booking.Email = col["Email"];
                booking.PhoneNumber = col["PhoneNumber"];
                //Konverterar till DateTime innan lagring
                booking.Date = Convert.ToDateTime(col["Date"]);
                booking.Time = Convert.ToDateTime(col["Time"]);
                
                //Gör om objektet till json-sträng
                string json = JsonConvert.SerializeObject(booking);
                //Sparar i en session
                HttpContext.Session.SetString("booking", json);

                ViewData["BookingOutput"] = "Ditt bord är nu bokat!";

            }
            ViewData["Title"] = "Boka bord";
            return View();
        }
        
        [HttpGet("/bokning")]
        public IActionResult Bookings()
        {
            ViewData["Title"] = "Bokning";
            
            //Instans av modellen
            BookTable booking = new BookTable();
            //Hämtar in sessionen.
            string bookings = HttpContext.Session.GetString("booking");
            //Kollar om session hämtates in
            if(bookings == null)
            {
                ViewData["bookings"] = "Finns ingen bokning.";
                return View();
            } else
            {
                //Gör om json-text till objekt
                booking = JsonConvert.DeserializeObject<BookTable>(bookings);
                return View(booking);
            }
        }


        [HttpGet("/ändrameny")]
        public IActionResult ChangeMenu()
        {
            Headline changeMenuHeadline = new Headline("Ändra menyn");
            return View(changeMenuHeadline);
        }

        [HttpGet("/nyförrätt")]
        public IActionResult AddAppertizer()
        {
            ViewData["Title"] = "Lägg till förrätt";
            return View();
        }

        [HttpPost("/nyförrätt")]
        public IActionResult AddAppertizer(Appetizer model)
        {
            if(ModelState.IsValid)
            {
                //Läs in JSON-fil
                var JsonStr = System.IO.File.ReadAllText("appetizer.json");
                //Gör om object i JSON-filen till objekt från modellen.
                var JsonObj = JsonConvert.DeserializeObject<List<Appetizer>>(JsonStr);
                //Konvertera till Json-sträng
                JsonObj.Add(model);
                System.IO.File.WriteAllText("appetizer.json", JsonConvert.SerializeObject(JsonObj, Formatting.Indented));

                //Rensar formuläret
                ModelState.Clear();
                
                ViewData["output"] = "Förrätt tillagd";
                
            }
            ViewData["Title"] = "Lägg till förrätt";
            return View();
        }
    }
}