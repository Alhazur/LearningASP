using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningASP.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearningASP.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Swing()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Swing(string angle, string velocity)
        {
            double numAngle = 0;
            double numVelocity = 0;

            angle = angle.Replace(".", ",");
            velocity = velocity.Replace(".", ",");

            double.TryParse(angle, out numAngle);
            double.TryParse(velocity, out numVelocity);

            ViewBag.Distance = Golf.Distance(numAngle, numVelocity);//klass golf + method

            return View();
        }
    }
}
