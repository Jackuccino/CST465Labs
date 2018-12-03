using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Match
    {
        public List<Team> TeamList = null;
        public List<Match> GroupA = null;
        public List<Match> GroupB = null;
        public List<Match> GroupC = null;
        public List<Match> GroupD = null;
        public List<Match> GroupE = null;
        public List<Match> GroupF = null;
        public List<Match> GroupG = null;
        public List<Match> GroupH = null;

        public int Id { get; set; }
        [Required]
        [Display(Name = "Home Team")]
        public int HomeTeamId { get; set; }
        [Display(Name = "Home Goals")]
        public int HomeGoals { get; set; }
        [Required]
        [Display(Name = "Away Team")]
        public int AwayTeamId { get; set; }
        [Display(Name = "Away Goals")]
        public int AwayGoals { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Match Date")]
        public string MatchDate { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Match Time")]
        public string MatchTime { get; set; }
        [Required]
        [Range(1, 6)]
        [Display(Name = "Group stage - Matchday #/6")]
        public int MatchDayNumber { get; set; }
    }
}
