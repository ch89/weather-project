using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models.Abstract
{
    public abstract class RepositoryBase : IRepository
    {
        protected abstract IQueryable<Forecast> QueryForecasts();

        public IEnumerable<Forecast> GetForecasts()
        {
            return QueryForecasts().ToList();
        }

        public Forecast GetForecastById(int forecastId)
        {
            return QueryForecasts().SingleOrDefault(f => f.ForecastId == forecastId);
        }

        public abstract void InsertForecast(Forecast forecast);
        public abstract void UpdateForecast(Forecast forecast);
        public abstract void DeleteForecast(int forecastId);

        protected abstract IQueryable<Location> QueryLocations();

        public IEnumerable<Location> GetLocations()
        {
            return QueryLocations().ToList();
        }

        public Location GetLocationById(int locationId)
        {
            return QueryLocations().SingleOrDefault(l => l.LocationId == locationId);
        }

        public Location GetLocationByCity(string city)
        {
            return QueryLocations().SingleOrDefault(l => l.City == city);
        }

        public abstract void InsertLocation(Location location);
        public abstract void UpdateLocation(Location location);
        public abstract void DeleteLocation(int locationId);

        public abstract void Save();
    }
}