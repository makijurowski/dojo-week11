using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using DojoLeague.Models;
using Microsoft.AspNetCore.Identity;
using MySql.Data.MySqlClient;

namespace DojoLeague.Factories
{
    public class UserFactory : IFactory<User>
    {
        private new string connectionString;

        public UserFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=mydb;SslMode=None";
        }

        internal new IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(connectionString);
            }
        }

        public void Add(User item)
        {
            using(IDbConnection dbConnection = Connection)
            {
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                item.Password = hasher.HashPassword(item, item.Password);
                string query = "INSERT INTO Users (first_name, last_name, email, password, created_at, updated_at) VALUES(@First_Name, @Last_Name, @Email, @Password, NOW(), NOW()); SELECT LAST_INSERT_ID() as id";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }

        public IEnumerable<User> FindAll()
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM users");
            }
        }

        public User FindById(int id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM users WHERE id = @id", new { Id = id }).FirstOrDefault();
            }
        }

        public User FindByEmail(string email)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM users WHERE email = @email", new { Email = email }).FirstOrDefault();
            }
        }
    }
}