using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDealership.Models;

namespace CarDealership.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IList<Car> vm;

            using (var db = new DealershipContext())
            {
                vm = db.Cars.ToList();
            }

            return View(vm);
        }
    }
}