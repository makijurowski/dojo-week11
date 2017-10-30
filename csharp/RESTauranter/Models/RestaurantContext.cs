using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore;

namespace RESTauranter.Models
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options) { }
    
        // DbSet contains "User" objects and links with table "Users"
        public DbSet<User> Users { get; set; }
    }
}