using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using LearningASP.Models;

namespace LearningASP.Controllers
{
    public class BakeryController : Controller//skappa Controller till ICakeService, MockCakeService
    {
        ICakeService _cakeService;//Injection objeckt

        public BakeryController(ICakeService cakeService)
        {
            _cakeService = cakeService;
        }

        public IActionResult Index()
        {
            return View(_cakeService.AllCakes());
        }

        [HttpPost]
        public IActionResult Index( string name, int price,string details)
        {
            _cakeService.CreateCake(name, price, details);//till create i html och skappa knappar till dom

            return View(_cakeService.AllCakes());
        }

        public IActionResult AJAXPartialExample (int id)//eto ajax
        {
            
            return PartialView("_Cake", _cakeService.FindCake(id)); //Partial nazvanie model name
        }
    }
}