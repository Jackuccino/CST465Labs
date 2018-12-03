using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Team
    {
        public List<Team> GroupA = null;
        public List<Team> GroupB = null;
        public List<Team> GroupC = null;
        public List<Team> GroupD = null;
        public List<Team> GroupE = null;
        public List<Team> GroupF = null;
        public List<Team> GroupG = null;
        public List<Team> GroupH = null;

        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string TeamName { get; set; }
        [Required]
        [DataType(DataType.Url)]
        public string Badge { get; set; }
        public int MatchesPlayed
        {
            get
            {
                return Wins + Draws + Loses;
            }
        }
        [Required]
        [DataType(DataType.Text)]
        [Range(0, 6)]
        public int Wins { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Range(0, 6)]
        public int Draws { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Range(0, 6)]
        public int Loses { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Range(0, 99)]
        [Display(Name = "Goals For")]
        public int GoalsFor { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Range(0, 99)]
        [Display(Name = "Goals Against")]
        public int GoalsAgainst { get; set; }
        public int GoalsDifference
        {
            get
            {
                return GoalsFor - GoalsAgainst;
            }
        }
        public int Points
        {
            get
            {
                return Wins * 3 + Draws * 1;
            }
        }
        [Required]
        [DataType(DataType.Text)]
        public char Group { get; set; }
    }
}
