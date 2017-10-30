using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using DojoLeague.Models;
using Microsoft.AspNetCore.Identity;
using MySql.Data.MySqlClient;

namespace DojoLeague.Factories
{
    public class DojoFactory : IFactory<Dojo>
    {
        public void Add(Dojo dojo)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "INSERT INTO Dojos (Name, Level, Location, Description) VALUES(@Name, @Level, @Location, @Description; SELECT LAST_INSERT_ID() as Id";
                dbConnection.Open();
                dbConnection.Execute(query, dojo);
            }
        }

        public IEnumerable<Dojo> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Dojo>("SELECT * FROM Dojos");
            }
        }

        public Dojo FindById(int Id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Dojo>("SELECT * FROM Dojos WHERE Id = @Id", new { Id = Id }).FirstOrDefault();
            }
        }

        public Dojo FindByName(string Name)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Dojo>("SELECT * FROM Dojos WHERE Name = @Name", new { Name = Name }).FirstOrDefault();
            }
        }

        public IEnumerable<Dojo> FindNinjasByLocation(string Location)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Dojo>("SELECT * FROM Ninjas WHERE Location = @Location", new { Location = Location });
            }
        }
    }
}