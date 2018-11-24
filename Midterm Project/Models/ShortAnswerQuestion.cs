using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Midterm.Models
{
    public class ShortAnswerQuestion : TestQuestion
    {
        public ShortAnswerQuestion(TestQuestion question)
        {
            ID = question.ID;
            Question = question.Question;
            Type = question.Type;
            Choices = question.Choices;
        }

        [Required]
        [StringLength(100)]
        public override string Answer
        {
            get => base.Answer;
            set => base.Answer = value;
        }
    }
}
