using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdeaExchange
{
    public partial class Likes
    {
        [Key]
        public int LikeId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public Posts Post { get; set; }
    }

    public partial class likes_users
    {
        [Key]
        public int LikeId { get; set; }
        public int UserId { get; set; }
        public string Alias { get; set; }
        public string Fname { get; set; }
        public int PostId { get; set; }
    }
}