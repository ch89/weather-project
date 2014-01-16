using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json.Linq;

namespace Project.Models.Webservices
{
    public class WeatherWebservice
    {
        public Location GetLocation(string city)
        {
            string rawJson = String.Empty;

            string url = String.Format("http://maps.googleapis.com/maps/api/geocode/json?address={0}&sensor=false", city);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            using (WebResponse res = request.GetResponse())
            using (var reader = new StreamReader(res.GetResponseStream()))
            {
                rawJson = reader.ReadToEnd();
            }

            JObject jObject = JObject.Parse(rawJson);

            return ((JArray)jObject["results"]).Select(l => new Location(l)).First();
        }

        public IEnumerable<Forecast> GetForecasts(Location location)
        {
            string rawJson = String.Empty;

            var url = String.Format("http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&units=metric&cnt=5", location.City);
            var request = (HttpWebRequest)WebRequest.Create(url);
            
            using(var response = request.GetResponse())
            using(var reader = new StreamReader(response.GetResponseStream())) {
                rawJson = reader.ReadToEnd();
            }

            JObject jObject = JObject.Parse(rawJson);

            return ((JArray)jObject["list"]).Select(f => new Forecast(f, location)).ToList();
        }
    }
}