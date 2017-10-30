using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using DojoLeague.Models;
using Microsoft.AspNetCore.Identity;
using MySql.Data.MySqlClient;

namespace DojoLeague.Factories
{
    public class IFactory<T> where T : BaseEntity
    {
        public string connectionString;

        public IFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=dojo;SslMode=None";
        }

        internal IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(connectionString);
            }
        }
    }
}