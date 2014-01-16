using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace Project.Models
{
    public partial class Location
    {
        public Location(JToken token)
        {
            Address = (string)token["formatted_address"];
            Longitude = (double)token["geometry"]["location"]["lng"];
            Latitude = (double)token["geometry"]["location"]["lat"];

            this.Forecasts = new HashSet<Forecast>();
        }
    }
}