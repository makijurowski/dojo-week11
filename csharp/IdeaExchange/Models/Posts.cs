using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdeaExchange
{
    public partial class Posts
    {
        public Posts()
        {
            Likes = new HashSet<Likes>();
        }
        [Key]
        public int PostId { get; set; }
        public string PostContent { get; set; }
        public int UserId { get; set; }
        public string Alias { get; set; }
        public ICollection<Likes> Likes { get; set; }
    }
}