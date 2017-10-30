using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace RESTauranter
{
    public class MySqlOptions
    {
        public string Name { get; set; }
        public string ConnectionString { get; set; }
    }
}