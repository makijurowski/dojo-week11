using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuotingDojo.Models
{
    public class AuthorViewModel : BaseEntity
    {
        [Required]
        [MinLength(2)]
        public string author_name { get; set; }
    }
}