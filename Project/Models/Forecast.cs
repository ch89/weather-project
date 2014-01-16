using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace Project.Models
{
    public partial class Forecast
    {
        public Forecast()
        {
        }

        public Forecast(JToken token, Location location)
        {
            Temperature = (double)token["temp"]["day"];
            Description = (string)token["weather"][0]["description"];
            Icon = (string)token["weather"][0]["icon"];
            LocationId = location.LocationId;
            Location = location;
        }
    }
}