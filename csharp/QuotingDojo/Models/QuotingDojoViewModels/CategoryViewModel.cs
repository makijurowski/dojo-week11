using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuotingDojo.Models
{
    public class CategoryViewModel : BaseEntity
    {
        [Required]
        public string category_name { get; set; }
    }
}