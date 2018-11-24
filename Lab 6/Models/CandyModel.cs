using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Lab_5.Repositories;

namespace Lab_5.Models
{
    public class CandyModel
    {
        public List<Candy> CandyList = null;
        
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
    }
}
