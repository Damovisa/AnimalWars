using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using AnimalWars.Models;
using Dapper;
using Microsoft.ApplicationInsights;

namespace AnimalWars.Data
{
    public class AnimalWarsData
    {
        private SqlConnection _cnn;
        private TelemetryClient _telemetryClient;

        public AnimalWarsData()
        {
            _cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["AnimalWarsConnection"].ConnectionString);
            _telemetryClient = new TelemetryClient();
        }


        public AnimalWar GetSingleWar(Category animalCategory)
        {
            try
            {
                var query =
                    "SELECT TOP 2 Id, Name, Category, Count FROM Animals WHERE Category = @category ORDER BY newid()";
                var animals = _cnn.Query<Animal>(query, new { category = animalCategory.ToString() }).ToList();
                return new AnimalWar
                {
                    AnimalOne = animals.First(),
                    AnimalTwo = animals.ElementAt(1)
                };
            }
            catch (Exception ex)
            {
                _telemetryClient.TrackException(ex);
                throw;
            }
        }

        public void IncrementCount(string id)
        {
            try
            {
                var query = "UPDATE Animals SET Count = Count + 1 WHERE Id = @id";
                _cnn.Execute(query, new { id });
            }
            catch (Exception ex)
            {
                _telemetryClient.TrackException(ex);
                throw;
            }

        }
    }
}