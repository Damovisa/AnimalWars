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

        public AnimalWarsData()
        {
            _cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["AnimalWarsConnection"].ConnectionString);
        }


        public AnimalWar GetSingleWar(Category animalCategory)
        {
            var query =
                "SELECT TOP 2 Id, Name, Category, Image, Count FROM Animals WHERE Category = @category ORDER BY newid()";
            var animals = _cnn.Query<Animal>(query, new { category = animalCategory.ToString() }).ToList();
            return new AnimalWar
            {
                //Category = animals.First().Category,
                AnimalOne = animals.First(),
                AnimalTwo = animals.ElementAt(1)
            };
        }

        public void IncrementCount(string id)
        {
            var query = "UPDATE Animals SET Count = Count + 1 WHERE Id = @id";
            _cnn.Execute(query, new { id });
        }
    }
}