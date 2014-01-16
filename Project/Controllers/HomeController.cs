using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;
using Project.Models.Webservices;
using Project.ViewModel;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View("Index");
        }

        //
        // POST: /Home/

        [HttpPost]
        public ActionResult Index([Bind(Include = "City")]HomeIndexViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var service = new Service();
                    model.Forecasts = service.GetForecasts(model.City);
                    model.Location = model.Forecasts.First().Location;
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Couldn't find location.");
            }

            return View("Index", model);
        }
    }
}
