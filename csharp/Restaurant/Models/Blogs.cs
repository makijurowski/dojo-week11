using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Restaurant.Models;

namespace Restaurant
{
    public partial class Blogs
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public JsonObject<Blogs> Tags { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }

        public Users User { get; set; }
    }
}
