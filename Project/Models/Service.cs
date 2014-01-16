using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models.Abstract;
using Project.Models.Repositories;
using Project.Models.Webservices;

namespace Project.Models
{
    public class Service : IService
    {
        private IRepository repository;

        public Service() 
            : this(new Repository())
        {

        }

        public Service(IRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Forecast> GetForecasts(string city)
        {
            var location = repository.GetLocationByCity(city);

            if (location == null)
            {
                var webservice = new WeatherWebservice();
                location = webservice.GetLocation(city);
                location.City = city;

                repository.InsertLocation(location);
                repository.Save();
            }

            if (!location.Forecasts.Any() || location.NextUpdate < DateTime.Now)
            {
                location.Forecasts.ToList().ForEach(f => repository.DeleteForecast(f.ForecastId));

                var webservice = new WeatherWebservice();
                foreach(var forecast in webservice.GetForecasts(location)) 
                {
                    repository.InsertForecast(forecast);
                }

                location.NextUpdate = DateTime.Now.AddHours(3);
                repository.Save();
            }

            return location.Forecasts.ToList();
        }
    }
}