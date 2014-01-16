using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Project.Models;

namespace Project.ViewModel
{
    public class HomeIndexViewModel
    {
        [Required(ErrorMessage = "No location specified.")]
        [DisplayName("Location")]
        public string City { get; set; }

        public bool HasForecasts
        {
            get
            {
                return Forecasts != null && Forecasts.Any();
            }
        }

        public string Address
        {
            get
            {
                return Location != null ? Location.Address : "Unknown";
            }
        }

        public IEnumerable<Forecast> Forecasts { get; set; }
        public Location Location { get; set; }
    }
}