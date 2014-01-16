using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Abstract
{
    public interface IRepository
    {
        IEnumerable<Forecast> GetForecasts();
        Forecast GetForecastById(int forecastId);
        void InsertForecast(Forecast forecast);
        void UpdateForecast(Forecast forecast);
        void DeleteForecast(int forecastId);

        IEnumerable<Location> GetLocations();
        Location GetLocationById(int locationId);
        Location GetLocationByCity(string city);
        void InsertLocation(Location location);
        void UpdateLocation(Location location);
        void DeleteLocation(int locationId);

        void Save();
    }
}
