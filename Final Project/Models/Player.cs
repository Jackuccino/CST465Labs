using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Player
    {
        public List<Player> PlayerList = null;
        public List<Team> TeamList = null;

        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Position { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Nationality { get; set; }
        [Required]
        [Range(1,99)]
        [Display(Name = "Jersey Number")]
        public int JerseyNumber { get; set; }
        [Required]
        [Display(Name = "Goal Scored")]
        public int GoalScored { get; set; }
        [Required]
        [Display(Name = "Team")]
        public int TeamId { get; set; }
    }
}
