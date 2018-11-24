using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Lab_5.Repositories;

namespace Lab_5.Models
{
    public class TreaterModel
    {
        public List<Candy> CandyList = null;
        public List<Costume> CostumeList = null;
        public List<Treater> TreaterList = null;

        public TreaterModel()
        {
            ICandyRepository candyRepo = new CandyDBRepository();
            CandyList = new List<Candy>(candyRepo.GetList());

            ICostumeRepository costumeRepo = new CostumeDBRepository();
            CostumeList = new List<Costume>(costumeRepo.GetList());

            ITreaterRepository treaterRepo = new TreaterDBRepository();
            TreaterList = new List<Treater>(treaterRepo.GetList());
        }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Favorite Candy is required.")]
        public int FavoriteCandyID { get; set; }
        [Required(ErrorMessage = "Costume is required.")]
        public int CostumeID { get; set; }
    }
}
