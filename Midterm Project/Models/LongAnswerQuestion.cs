using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Midterm.Models
{
    public class LongAnswerQuestion : TestQuestion
    {
        public LongAnswerQuestion(TestQuestion question)
        {
            ID = question.ID;
            Question = question.Question;
            Type = question.Type;
            Choices = question.Choices;
        }

        [Required]
        public override string Answer
        {
            get => base.Answer;
            set => base.Answer = value;
        }
    }
}
