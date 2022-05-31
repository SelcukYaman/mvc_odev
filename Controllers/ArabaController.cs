using Microsoft.AspNetCore.Mvc;
using MvcDenemeHello.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcDenemeHello.Controllers
{
    public class ArabaController : Controller
    {
        List<Araba> lst = new List<Araba>(){
        new Araba(1, "reno", 1997, 4),
        new Araba(2, "bmw", 2020, 4),
        new Araba(3, "woswogen", 2013, 4),
        new Araba(4, "volvo", 2018, 4)
        };
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult ArabaBilgi(int? id=1)
        {
            
            lst.Capacity = lst.Count;

            var arabalar = from arb in lst
                           where arb.Arabaid==id
                           select arb;

            return View(arabalar.FirstOrDefault());//bulunan sonuçlardan ilkini getirir.
        }
        public IActionResult Arabalistele()
        {
            
            lst.Capacity = lst.Count;
            return View(lst);
        }
    }
}
