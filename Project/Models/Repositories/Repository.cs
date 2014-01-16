using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Project.Models.Abstract;
using Project.Models.DataModels;

namespace Project.Models.Repositories
{
    public class Repository : RepositoryBase
    {
        private UD12_ch222ih_WeatherEntities entities = new UD12_ch222ih_WeatherEntities();

        protected override IQueryable<Forecast> QueryForecasts()
        {
            return entities.Forecasts.AsQueryable();
        }

        public override void InsertForecast(Forecast forecast)
        {
            entities.Forecasts.Add(forecast);
        }

        public override void UpdateForecast(Forecast forecast)
        {
            entities.Entry(forecast).State = EntityState.Modified;
        }

        public override void DeleteForecast(int forecastId)
        {
            Forecast forecast = entities.Forecasts.Find(forecastId);
            entities.Forecasts.Remove(forecast);
        }


        protected override IQueryable<Location> QueryLocations()
        {
            return entities.Locations.AsQueryable();
        }

        public override void InsertLocation(Location location)
        {
            entities.Locations.Add(location);
        }

        public override void UpdateLocation(Location location)
        {
            entities.Entry(location).State = EntityState.Modified;
        }

        public override void DeleteLocation(int locationId)
        {
            Location location = entities.Locations.Find(locationId);
            entities.Locations.Remove(location);
        }

        public override void Save()
        {
            entities.SaveChanges();
        }
    }
}