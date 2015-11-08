using System;
using System.Web.Mvc;
using AnimalWars.Data;
using AnimalWars.Models;

namespace AnimalWars.Controllers
{
    public class HomeController : Controller
    {
        private AnimalWarsData _animalWarsData;

        public HomeController()
        {
            _animalWarsData = new AnimalWarsData();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Land()
        {
            var war = _animalWarsData.GetSingleWar(Category.Land);
            return View("War", war);
        }

        public ActionResult Sea()
        {
            var war = _animalWarsData.GetSingleWar(Category.Sea);
            return View("War", war);
        }

        public ActionResult Flying()
        {
            var war = _animalWarsData.GetSingleWar(Category.Flying);
            return View("War", war);
        }

        public ActionResult Imaginary()
        {
            var war = _animalWarsData.GetSingleWar(Category.Imaginary);
            return View("War", war);
        }

        [HttpPost]
        public ActionResult War(string animal1, string animal2, string category)
        {
            _animalWarsData.IncrementCount(animal1 ?? animal2);
            return RedirectToAction(category);
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}