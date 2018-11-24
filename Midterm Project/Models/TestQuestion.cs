using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm.Models
{
    public class TestQuestion
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Question { get; set; }
        public string[] Choices { get; set; }
        [Required(ErrorMessage = "This question has not been answered.")]
        public virtual string Answer { get; set; }
    }
}
