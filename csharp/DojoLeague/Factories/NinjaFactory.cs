using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using DojoLeague.Models;
using Microsoft.AspNetCore.Identity;
using MySql.Data.MySqlClient;

namespace DojoLeague.Factories
{
    public class NinjaFactory : IFactory<Ninja>
    {
        public void AddNinja(Ninja ninja)
        {
            using(IDbConnection dbConnection = Connection)
            {
                string query = "INSERT INTO Ninjas (Name, Level, Location, Description) VALUES(@Name, @Level, @Location, @Description); SELECT LAST_INSERT_ID() as Id";
                dbConnection.Open();
                dbConnection.Execute(query, ninja);
            }
        }

        public IEnumerable<Ninja> FindAll()
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninja>("SELECT * FROM Ninjas");
            }
        }

        public Ninja FindById(int Id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninja>("SELECT * FROM Ninjas WHERE Id = @Id", new { Id = Id }).FirstOrDefault();
            }
        }

        public Ninja FindByName(string Name)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninja>("SELECT * FROM Ninjas WHERE Name = @Name", new { Name = Name }).FirstOrDefault();
            }
        }

        public IEnumerable<Ninja> FindByLocation(string Location)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninja>("SELECT * FROM Ninjas WHERE Location = @Location", new { Location = Location });
            }
        }
    }
}